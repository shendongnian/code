    public class WCFNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<DummyLogger>();
        }
    }
