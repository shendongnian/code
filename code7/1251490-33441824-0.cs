    public partial class App : Application
    {
        public AppColors appColors { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            this.appColors = new AppColors();
            base.OnStartup(e);
        }
    }
