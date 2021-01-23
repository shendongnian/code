        private static ManualResetEvent mre = new ManualResetEvent(false);
        public MainPage()
        {
            this.InitializeComponent();
            Task.Run(() => {
                mre.WaitOne();
                Debug.WriteLine("do sth else"); 
            });
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            mre.Set(); 
        }
