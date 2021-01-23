    using System;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            DispatcherTimer timer = new DispatcherTimer();
    
    
            public MainWindow()
            {
                InitializeComponent();
                timer.Tick += new EventHandler(timer_tick);
                timer.Interval = new TimeSpan(0, 0, 1);
    
            }
    
            int dynCount = 0;
    
            private void timer_tick(object sender, EventArgs e)
            {
                dynCount++;
                dynNum.Content = dynCount.ToString();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                timer.Start();
    
            }
    
    
        }
    }
