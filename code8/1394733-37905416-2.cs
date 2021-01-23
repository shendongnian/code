    protected override void OnStartup(StartupEventArgs e) {
         base.OnStartup(e);
         this.DispatcherUnhandledException += AppGlobalDispatcherUnhandledException;
    }
    
    private void AppGlobalDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
         e.Handled = true;
    }
