        // Constructor
        public SettingsWindow()
        {
            InitializeComponent();
            Closing += SettingsWindow_Closing; // Subscribe to window closing event.
        }
        // Window closing event handler.
        private void SettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Add method you want to run on close here.
        }
