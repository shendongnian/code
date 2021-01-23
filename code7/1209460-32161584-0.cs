        public App()
        {
            InitializeComponent();
            UnhandledException += OnUnhandledException;
        }
        protected override void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Optionally use e.Handled = true;
            // Send to Google Ananlytics
        }
