    public partial class App : System.Windows.Application
    {
        public App()
        {
            this.DispatcherUnhandledException += this.OnDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += this.OnAppDomainUnhandledException;
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += this.OnUnobservedTaskException;
        }
        private void OnAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Logger("AppDomainUnhandledException", e.ExceptionObject as Exception);
        }
        private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Log.Logger("DispatcherUnhandled: ", e.Exception);
        }
        private void OnUnobservedTaskException(object sender, System.Threading.Tasks.UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            Log.Logger("UnobservedTaskException", e.Exception);
        }
    }
