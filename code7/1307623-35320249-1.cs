    public void TestCanInterceptMethods() {
        // Create a concrete instance, using the factory
        var coreInstance = SqlUtilFactory.CreateSqlUtil();
        // Test that the concrete instance works
        Assert.AreEqual(42, coreInstance.SomeMethodToIntercept());
        Assert.AreEqual(40, coreInstance.SomeGenericMethod(40));
        // Create a proxy generator (you'll probably want to put this
        // somewhere static so that it's caching works if you use it)
        var generator = new Castle.DynamicProxy.ProxyGenerator();
        // Use the proxy to generate a new class that implements ISqlUtil
        // Note the concrete instance is passed into the construction
        // As is an instance of MethodInterceptor (see below)
        var proxy = generator.CreateInterfaceProxyWithTarget<ISqlUtil>(coreInstance, 
                                    new MethodInterceptor<int>("SomeMethodToIntercept", 33));
        // Check that calling via the proxy still delegates to existing 
        // generic method
        Assert.AreEqual(45, proxy.SomeGenericMethod(45));
        // Check that calling via the proxy returns the result we've specified
        // for our intercepted method
        Assert.AreEqual(33, proxy.SomeMethodToIntercept());
    }
