    private MemoryAppender testAppender;
    [SetUp]
    public void SetUp()
    {
        testAppender = new MemoryAppender();
        BasicConfigurator.Configure(testAppender);
 
        // etc    
    }
 
    [Test]
    public void TestLogging()
    {
       // etc
  
       var events = testAppender().GetEvents();
       Assert.AreEqual(1, events.Count()); 
    }
