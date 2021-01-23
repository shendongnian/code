        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.LeavingBackground += App_LeavingBackground;
            this.Resuming += App_Resuming;
        }
