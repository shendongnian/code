    [Fact]
    public void GetInstance_SpecificLifestyleWithinAScope_IsTheSameInstance()
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
        container.Register<IService, Service>(Lifestyle.Scoped);
        container.Verify();
        using (container.BeginLifetimeScope())
        {
            var a = container.GetInstance<IService>();
            var b = container.GetInstance<IService>();
            Assert.Same(a, b);
        }
    }
