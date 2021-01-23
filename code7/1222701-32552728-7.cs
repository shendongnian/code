    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Begin Composition Root
            new StandardKernel(new MyApplicationModule()).Get<IWindow>().Show();
            // End Composition Root
        }
    }
