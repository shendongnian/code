    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            private DispatcherTimer timer;
            private int counter = 0;
    
            public MainPage()
            {
                this.InitializeComponent();
                timer = new DispatcherTimer();
    
                Loaded += MainPage_Loaded;
            }
    
            private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                timer.Interval = TimeSpan.FromSeconds(1.0);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
    
            private void Timer_Tick(object sender, object e)
            {
                if (counter == 10)
                {
                    //do operation in every 10 seconds
                    counter = 0;
                    //if you want to stop the timer use timer.Start()
                }
                else
                {
                    counter++;
                }
            }
        }
    }
