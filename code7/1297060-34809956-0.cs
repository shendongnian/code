    [TestMethod]
    public void GetAll()
    {
        // *Arrange*
        var mockSet = new Mock<DbSet<Person>>(); 
 
        var mockContext = new Mock<DatabaseContext>(); 
        mockContext.Setup(m => m.Person).Returns(mockSet.Object); 
        // Configure the context to return something meaningful
        var sut = new PersonRepository(mockContext.Object);
        // *Act*
        var result = sut.GetAll()
        // *Assert* that the result was as expected
    }
