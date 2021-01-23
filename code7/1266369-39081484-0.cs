    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Window app_window = Shell as Window;
            if((app_window != null) && (Application.Current != null))
            {
               Application.Current.MainWindow = app_window;
               Application.Current.MainWindow.Show();
            }
        }
    
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(MainShellModule));
        }
    }
