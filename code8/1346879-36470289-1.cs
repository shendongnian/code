    [TestMethod, Isolated]
    public void TestGetCreatesNewEntity()
    {
        //Assert
        IRepository someRepository = new MyRepository();
        MyService service = new MyService(someRepository);
    
        List<MyEntity> entities = new List<MyEntity>();
        Isolate.WhenCalled(() => service.GetAllEntities()).WillReturn(entities.AsQueryable());
    
        //Act
        MyEntity result = service.GetEntity(1);
    
        //Assert
        Assert.AreEqual(-1, result.ID);
        Assert.AreEqual("New Entity", result.Title);
    }
