    public void TestContainer()
    {
        using (MyContainer.Container.BeginExecutionContextScope()) {
            var parentContext = MyContainer.Container.GetInstance<DbContext>();
            TestParentAndChildContext(parentContext); 
        }
    }
    private void TestParentAndChildContext(MyContext parentContext)
    {
        var childContext = MyContainer.Container.GetInstance<DbContext>();
        Assert.AreEqual(parentContext, childContext);
    }
