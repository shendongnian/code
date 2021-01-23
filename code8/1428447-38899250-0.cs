    [Test]
    public void MyTest()
    {
        //Arrange
        const string id = "the id"
        var address = new Address{Id = id};
        var repository = new Mock<IRepository>(); //Using Moq here
        repository.Setup(r => r.Get(id))
                  .Returns(address);
        var sut = new AddressManager(repository.Object);
    
        //Act
        var returnedAddress = sut.GetAddress(id);
    
        //Assert
        repository.VerifyAll(); //Checks you're calling the repository with the "id"
        Assert.That(returnedAddress, Is.EqualTo(address)); // This will pass because the reference is the same
    }
