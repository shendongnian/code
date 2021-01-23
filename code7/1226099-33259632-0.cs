    [TestCleanup]  
    public void testClean()  
    {  
        _Trans.Dispose();
    } 
  
    [TestInitialize]  
    public void testInit()  
    {  
        _Trans = new TransactionScope(); 
    }   
    [TestMethod]
    public void TestQuery()
    {
        // arrange
        //' insert data
        // act
        Obj Target = Obj.New();
        // Assert
        Assert.AreEqual("someValue",Obj.SomeProperty);
    }
