    [Fact]
    public void DecorateAllWith_Filtered_IsNotReturned()
    {
        var container = new StructureMap.Container(registry =>
        {
            registry.Scan(x =>
            {
                x.TheCallingAssembly();
                x.ConnectImplementationsToTypesClosing(typeof(IEntityRepository<>));
            });
            registry.For(typeof(IEntityRepository<>))
                .DecorateAllWith(typeof(CachingDecorator<>), instance => false);
        });
        var result = container.GetInstance<IEntityRepository<Entity1>>();
        Assert.IsNotType<CachingDecorator<Entity1>>(result);
    }
