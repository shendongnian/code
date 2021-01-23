    using Ninject.Modules;
    using System.Windows;
    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISystemEvents>().To<MySystemEvents>();
            Bind<ITrackerViewModelFactory>().To<TrackerViewModelFactory>();
            Bind<Window>().To<MainWindow>();
            Bind<IWindow>().To<MainWindowAdapter>();
        }
    }
