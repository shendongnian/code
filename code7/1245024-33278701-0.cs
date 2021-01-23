    public void Merge(this IContainer container1, IContainer container2)
    { 
        var newBuilder = new ContainerBuilder();
        newBuilder.RegisterInstance(container2.Resolve<ISomeService1>()).AsImplementedInterfaces();
        newBuilder.RegisterInstance(container2.Resolve<ISomeService2>()).AsImplementedInterfaces();
        newBuilder.Update(container1);
        return container1;
    }
