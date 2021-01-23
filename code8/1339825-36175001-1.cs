    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDealsService>().To<DealsService>();
            Bind<DealsParser>().To<DealsParser>();
        }
    }
