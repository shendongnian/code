    public MainPage()
            {
                InitializeComponent();
                Loaded+=MainPage_Loaded;
            }
    
            private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                var timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Start();
                timer.Tick += ((ax, by) => { timer.Stop();
                NavigationService.Navigate(new Uri("/Source Code/Recieve.xaml", UriKind.RelativeOrAbsolute));
                });            
            }
