    [TestMethod]
    public void Test1()
    {
        // This would be the value you previously stored in the Application property
        object fooValue = <some value>;
        YourClassName cls = new YourClassName();
        cls.MethodUnderTest(fooValue);
    }
