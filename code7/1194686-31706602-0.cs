    [TestMethod]
    public void MyTestMethod()
    {
        var cb = new ContainerBuilder();
        cb.RegisterGeneric(typeof(IsolatedLifetimeScopeFactory<>))
            .SingleInstance();
        var container = cb.Build();
        using (var scope1 = container.BeginLifetimeScope("scope1"))
        using (var scope2 = scope1.BeginLifetimeScope("scope2"))
        {
            var factory = container.Resolve<IsolatedLifetimeScopeFactory<object>>();
            var tag = factory._scope.Tag; // made _scope public for testing purposes
            Assert.AreNotEqual("scope1", tag);
            Assert.AreNotEqual("scope2", tag);
            // This particular string "root" is probably not guaranteed behavior, but
            // being in the root scope is guaranteed for SingleInstance registrations.
            Assert.AreEqual("root", tag);
        }
    }
