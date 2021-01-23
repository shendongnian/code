    [TestMethod,Isolated]
    public void TestMethod1()
    {
        var a = Isolate.Fake.Instance<A>(Members.CallOriginal);
    
        Isolate.WhenCalled(() => a.Foo()).WillReturn("TestWorked");
    
        var classUnderTest = new Class1();
        var result = classUnderTest.DoFoo(a);
    
        Assert.AreEqual("TestWorked", result);
    }
