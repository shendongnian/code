    internal interface IUnitCollectorFactory
    {
        IUnitCollector Create(Param2Type param2);
    }
    Bind<IUnitCollectorFactory>().ToFactory();
