    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            this.Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            var settings = new Dictionary<string, object>
            {
                { "SizeToContent", SizeToContent.Manual }
            };
            this.DisplayRootViewFor<MainViewModel>(settings);
        }
    }
