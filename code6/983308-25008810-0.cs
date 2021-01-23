    public class Repository
    {
        public Repository(ILogger logger) { }
    }
    Bind<Ilogger>().To(... some binding...);
    Bind<IRepository>().To<Repository>();
    IRepository repository = kernel.Get<IRepository>(); // creates an instance of `Repository` and injects an `ILogger` - which is to be resolved as specified by the `Bind<Ilogger>.To...` binding.
