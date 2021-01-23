    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Begin Composition Root
            var container = new StandardKernel();
            // Register types
            container.Bind<ISystemEvents>().To<MySystemEvents>();
            container.Bind<ITrackerViewModelFactory>().To<TrackerViewModelFactory>();
            container.Bind<Window>().To<MainWindow>();
            container.Bind<IWindow>().To<MainWindowAdapter>();
            // Build the application object graph
            var window = container.Get<IWindow>();
            // Show the main window.
            window.Show();
            // End Composition Root
        }
    }
