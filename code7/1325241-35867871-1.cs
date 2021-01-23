    [TestMethod]
    public void TestMethod1()
    {
        var fakeSingleton = Isolate.Fake.AllInstances<MyClass>();
    
        Isolate.WhenCalled(() => fakeSingleton.someFunction()).WillReturn(true);
    
        Assert.IsTrue(MyClass.Instance.someFunction());
     }
