    public void TestSetup()
    {
        //Setup tests
    }    
    public void TestCleanUpImpl()
    {
       //unassign variables
       //dispose disposable object
       GC.Collect();
    }
    public void TestImpl(int i) 
    {
        // Test stuff
        // Do assert statements here 
    }
    [TestMethod]
    public void Test()
    {
        int fromNum = 0;
        int untilNum = 9;
        for(int i=fromNum;i<=untilNum;i++)
        {
            TestSetup();
            TestImpl(i);
            TestCleanUpImpl();
        }
    }
