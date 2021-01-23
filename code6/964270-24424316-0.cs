    public partial class App
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;
