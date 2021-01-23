    [Fact]
    public void RegisterDecorator_AppliedToGenericType_IsReturned()
    {
        var container = new SimpleInjector.Container();
            
        container.RegisterManyForOpenGeneric(
            typeof(IEntityRepository<>), 
            typeof(IEntityRepository<>).Assembly);
            
        container.RegisterDecorator(
            typeof(IEntityRepository<>), 
            typeof(LoggingEntityRepository<>));
        var result = container.GetInstance<IEntityRepository<Entity1>>();
        Assert.IsType<LoggingEntityRepository<Entity1>>(result);
    }
