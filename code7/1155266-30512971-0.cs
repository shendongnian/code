    var isSingleton = container.Resolve<IRepository<String>>() == container.Resolve<IXRepository>();
    var outerInstance = container.Resolve<IXRepository>();
    using(var childContainer = container.CreateChildContainer())
    {
        isSingleton = childContainer.Resolve<IRepository<String>>() == childContainer.Resolve<IXRepository>();
        var isHierarchichalSingleton = outerInstance  != childContainer.Resolve<IXRepository>();
    }
