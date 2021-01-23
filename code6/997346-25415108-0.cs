        public MainWindow()
        {
            InitializeComponent();
    
            Task.Run(() =>
            {
                while (true)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var dtCurrentTime = DateTime.Now;
                        label1.Content = dtCurrentTime.ToLongTimeString();
                    }));
                    Thread.Sleep(1000);
                }
            });
        }
