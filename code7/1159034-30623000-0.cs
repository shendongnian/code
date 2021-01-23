    public partial class App
    {
        public App()
        {
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            base.OnStartup(e);
        }
    }
