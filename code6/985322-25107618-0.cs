    [Fact]
    public void VMsInSameScopeSharesService()
    {
        var container = new WindsorContainer();
        container.Register(Component.For<ViewModelA>().LifestyleTransient());
        container.Register(Component.For<ViewModelB>().LifestyleTransient());
        container.Register(Component
            .For<IService>().ImplementedBy<NullService>().LifestyleScoped());
        using (container.BeginScope())
        {
            var a = container.Resolve<ViewModelA>();
            Assert.Equal(a.service, a.childViewModel.service);
        }
    }
    [Fact]
    public void VMsInDifferentScopesDoNotShareServices()
    {
        var container = new WindsorContainer();
        container.Register(Component.For<ViewModelA>().LifestyleTransient());
        container.Register(Component.For<ViewModelB>().LifestyleTransient());
        container.Register(Component
            .For<IService>().ImplementedBy<NullService>().LifestyleScoped());
        IService service1;
        using (container.BeginScope())
        {
            var a = container.Resolve<ViewModelA>();
            service1 = a.service;
        }
        IService service2;
        using (container.BeginScope())
        {
            var a = container.Resolve<ViewModelA>();
            service2 = a.service;
        }
        Assert.NotEqual(service1, service2);
    }
