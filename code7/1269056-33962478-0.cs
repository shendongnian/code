    [Test]
    public void Test1()
    {
        var container = new Container();
        container.RegisterConditional<IService, Service1>(
            c => c.Consumer.ImplementationType == typeof(Consumer1));
        container.RegisterConditional<IService, Service2>(
            c => c.Consumer.ImplementationType == typeof(Consumer2));
        container.Register<Consumer1>();
        container.Register<Consumer2>();
        container.Verify();
        var result1 = container.GetInstance<Consumer1>();
        var result2 = container.GetInstance<Consumer2>();
        Assert.IsInstanceOf<Service1>(result1.Svc);
        Assert.IsInstanceOf<Service2>(result2.Svc);
    }
