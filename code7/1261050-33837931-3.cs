    [TestMethod]
    public TestMyMethod()
    {
      MockReliableStateManager stateManager = new MockReliableStateManager();
      MyService target = new MyService(stateManager);
      
      target.MyMethod();
      // validate results and all that good stuff
    }
