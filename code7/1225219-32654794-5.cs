    [Fact]
    public void GetInstance_NoSpecificLifestyleWithinAScope_IsAlwaysANewInstance()
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
        container.Register<IService, Service>();
        container.Verify();
        using (container.BeginLifetimeScope())
        {
            var a = container.GetInstance<IService>();
            var b = container.GetInstance<IService>();
            Assert.NotSame(a, b);
        }
    }
