    public App() {
            this.DispatcherUnhandledException += OnDispatcherUnhandledException;
        }
    
        void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
