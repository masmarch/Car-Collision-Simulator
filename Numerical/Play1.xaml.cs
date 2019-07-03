using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Numerical
{
    /// <summary>
    /// Interaction logic for Play1.xaml
    /// </summary>
    public partial class Play1 : Page
    {
        public Play1()
        {
            InitializeComponent();
        }
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        public static double v1;
        public static double v2;
        int c = 0;
        double s1=0,s2=0,a1=0,a2=0;

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Start.xaml", UriKind.RelativeOrAbsolute));
            timer2.Stop();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            timer1.Tick += new EventHandler(timecar1);
            timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer1.Start();
            timer2.Tick += new EventHandler(timecar2);
            timer2.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer2.Start();

        }

        private void timecar2(object sender, EventArgs e)
        {
            Canvas.SetLeft(truck1, Canvas.GetLeft(truck1) + 20);
            Canvas.SetLeft(truck2, Canvas.GetLeft(truck2) + 20);
            if (Canvas.GetLeft(truck2) > 850)
            {
                Canvas.SetLeft(truck1, -216);
                Canvas.SetLeft(truck2, -453);
            }
        }

        private void timecar1(object sender, EventArgs e)
        {
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(car2) - Canvas.GetTop(car1), 2) + Math.Pow(Canvas.GetLeft(car2) - Canvas.GetLeft(car1), 2));
            c++;
            
            
           
            Canvas.SetLeft(car1, Canvas.GetLeft(car1) + v1);
            Canvas.SetLeft(car2, Canvas.GetLeft(car2) - v2);
            if (Canvas.GetLeft(car1)+135 >= Canvas.GetLeft(car2) )
            {
                timer1.Stop();
                if (v1 == v2)
                {
                    Canvas.SetLeft(car1, Canvas.GetLeft(car1) + ((d-170) / 2));
                    Canvas.SetLeft(car2, Canvas.GetLeft(car2) - ((d-170) / 2));
                    Canvas.SetLeft(boom, Canvas.GetLeft(car2) - 45 );
                    count.Content = c;
                    count1.Content = c + 1;
                    a1 = v1 / c;
                    a2 = v2 / c;
                    s1 = (v1 - v2);
                    s2 = (v2 - v1);
                    acceleration1.Content = a1;
                    acceleration2.Content = a2;
                    distance.Content = s1;
                    distance1.Content = s2;

                }
                 else if (v1 > v2)
                {
                    Canvas.SetLeft(car2, (Canvas.GetLeft(car1)+135) + (v1-v2)*4);
                    Canvas.SetLeft(boom, Canvas.GetLeft(car1) + 80);
                    count.Content = c;
                    count1.Content = c + 1;
                    a1 = v1 / c;
                    a2 = v2 / c;                    
                    s2 = (v1 - v2);
                    acceleration1.Content = a1;
                    acceleration2.Content = a2;
                    distance.Content = s1;
                    distance1.Content = s2;

                }
                else if (v2>v1)
                {
                    Canvas.SetLeft(car1, ((Canvas.GetLeft(car2)-135) - (v2-v1)*4));
                    Canvas.SetLeft(boom, Canvas.GetLeft(car2) - 45);
                    count.Content = c;
                    count1.Content = c + 1;
                    a1 = v1 / c;
                    a2 = v2 / c;
                    s1 = (v2 - v1);                    
                    acceleration1.Content = a1;
                    acceleration2.Content = a2;
                    distance.Content = s1;
                    distance1.Content = s2;
                }
                Canvas.SetLeft(restart, 680);
            }
        }
    }
}
