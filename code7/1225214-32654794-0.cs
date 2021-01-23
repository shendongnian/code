    [Fact]
    public void GetInstance_NoSpecificLifestyleOutsideOfAnyScope_IsAlwaysANewInstance()
    {
        var container = new Container();
        container.Register<IService, Service>();
        container.Verify();
        var a = container.GetInstance<IService>();
        var b = container.GetInstance<IService>();
        Assert.NotSame(a, b);
    }
