    [TestMethod]
    public void ExpectToWork()
    {
        var repositoryMock = new Mock<IDummyRepository>();
        var serviceDummy = new ServiceDummy(repositoryMock.Object);
        var entity = new Dummy { DummyString = "DummyString" };
        repositoryMock.Setup(i => i.Add(It.IsAny<Dummy>())).Verifiable();
    
        serviceDummy.Add(entity);
        repositoryMock.Verify();
     }
