using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Fireworks_IT3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rocket> rockets = new List<Rocket>();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 33);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void DrawRockets()
        {
            CanvasSky.Children.Clear();
            foreach(var rocket in rockets)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 10;
                ellipse.Height = 10;
                ellipse.Fill = Brushes.White;
                Canvas.SetLeft(ellipse, rocket.Location.X);
                Canvas.SetTop(ellipse, rocket.Location.Y);
                CanvasSky.Children.Add(ellipse);
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (var rocket in rockets)
            {
                rocket.Move();
            }
            DrawRockets();
        }

        private void CanvasSky_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rocket rocket = new Rocket(new Point(100, 200), new Vector(2, -10), 2);
            rocket.Exploded += Rocket_Exploded;
            rockets.Add(rocket);
        }

        private void Rocket_Exploded(List<Rocket> obj)
        {
            rockets.AddRange(obj);
        }


    }
}
