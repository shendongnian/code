    [TestMethod]
    public void GetEntity_ValidName_EntityReturned()
    {
        Entity testEntity = new Entity();
        testEntity.Name = "Test";
    
        var mockEntityRepo = new Mock<IRepo>(); // Type of Repo here
        var mockService = new Mock<IUnitOfWork>();
        mockService.Setup(m => m.EntityRepo).Returns(mockEntityRepo.Object);
       mockEntityRepo .Setup(m => m.Find(It.IsAny<Predicate<string>>())).Returns(new List<Entity>() testEntity);
        Entity testEntity2 = EntityHelper.getEntity(mockService.Object, testEntity.Name);
        int count = testDB.EntityRepo.Count();
    
        Assert.AreEqual(testEntity.Name,testEntity2.Name);
    }
