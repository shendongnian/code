    var lazyContainer = new Lazy<IContainer>(() => containerBuilder.Build());
    containerBuilder.Register(c =>
    {
        var system = ActorSystem.Create("ExampleActorSystem");
        new AutoFacDependencyResolver(lazyContainer.Value, system);
        return system;
    }).As<ActorSystem>().SingleInstance();
