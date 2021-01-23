    using Ninject.Modules;
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHardwareService>().To<WindowsHardwareService>();
            Bind<IStatusApi>().To<StatusApiController>();
        }
    }
