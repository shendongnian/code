    [TestMethod]
    public void TestContainer()
    {
        var container = MyContainer.Container.GetInstance<DbContext>();
        var parentContext = container.GetInstance<MyContext>();
        var childContext = container.GetInstance<MyContext>();
        // This call will fail
        container.Verify();
    }
