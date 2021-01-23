    [TestMethod]
    public void ImportantMethod_PersonIsNull_NothingIsWrittenToDatabase(){
    
      // Arrange
      var writerMock = new Mock<IDataWriter<Person>>();
      var peopleManager = new PeopleManager(writerMock.Object);
    
      // Act
      peopleManager.ImportantMethodToTest(null);
    
      // Assert
      writerMock.Verify( writer => writer.Update(It.IsAny<Person>), Times.Never());
    
    
    }
