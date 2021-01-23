    [Fact]
    public void DecorateAllWith_AppliedToGenericType_IsReturned()
    {
        var container = new Container(registry =>
        {
            registry.Scan(x =>
            {
                x.TheCallingAssembly();
                x.ConnectImplementationsToTypesClosing(typeof(IEntityRepository<>));
                    
            });
            registry.For(typeof(IEntityRepository<>))
                .DecorateAllWith(typeof(LoggingEntityRepository<>));
        });
        var result = container.GetInstance<IEntityRepository<Entity1>>();
        Assert.IsType<LoggingEntityRepository<Entity1>>(result);
    }
