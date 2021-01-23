    [Test]
    public void ResolveLoggerDependency()
    {
        var module = new LoggerModule();
        var kernal = new StandardKernel(module);
        var test_object = kernal.Get<TestClass>();
        Assert.That(test_object.Logger, Is.Not.Null);
    }
