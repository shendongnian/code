    public static Main()
    {
        Production.Bootstrapper.Init(ServiceLocator.Instance);
        // or you can use
        // Simulation.Bootstrapper.Init(ServiceLocator.Instance);
        IDoable doable = ServiceLocator.Instance.Resolve<IDoable>();
        doable.Do();
    }
