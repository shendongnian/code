    ....
    var kernel = new StandardKernel();
    new NinjectDI(kernel).Load();
    kernel.Load(Assembly.GetExecutingAssembly());
    IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
    ...
 
    class NinjectDI : NinjectModule
    {
        StandardKernel kernel;
        public NinjectDI(StandardKernel kernel)
        {
            this.kernel = kernel;
        }
        public override void Load()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }
    }
