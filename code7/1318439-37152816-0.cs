        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.Resuming += App_Resuming;
        }
        private void App_Resuming(object sender, object e)
        {
           //Code to execute while resuming the app...
        }
