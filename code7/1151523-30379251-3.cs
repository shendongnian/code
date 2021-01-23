    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterInstance(new Foo()).AsSelf();
    IContainer container = builder.Build();
    using (ILifetimeScope scope = container.BeginLifetimeScope())
    {
        ContainerBuilder updater = new ContainerBuilder();
        updater.RegisterInstance(new Foo()).AsSelf(); // new instance of Foo
        updater.Update(scope.ComponentRegistry);
        scope.Resolve<Foo>(); // ==> new instance of Foo
    }
