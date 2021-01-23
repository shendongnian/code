        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;
            // ... existing code
        }
        private void OnAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log exception in more detail (note e.IsTerminating for interest)
        }
