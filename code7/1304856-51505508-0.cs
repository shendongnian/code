        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += this.OnCloseRequest;
        }
 
        private void OnCloseRequest(object sender, SystemNavigationCloseRequestedPreviewEventArgs e)
        {
            if (!saved) { e.Handled = true; SomePromptFunction(); }
        }
