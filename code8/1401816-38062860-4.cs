    [Test]
    public void Save_NewObjects_IdsUpdated() {
        //Arrange
        var expectedOriginalId = 0;
        var expectedUpdatedId = 1;
        var mock = new Mock<IPersistence>();
        mock.Setup(x => x.Save(It.Is<Class1>(o => o.Id == expectedOriginalId)))
            .Returns((Class1 c) => {
                // If it is a new object, then update the ID
                if (c.Id == 0) c.Id = expectedUpdatedId;
                return c;
            }).Verifiable();
        var sut = new Class1(mock.Object);
        var actualOriginalId = sut.Id;
    
        //Act
        sut.Save();
    
        //Assert
        //verify id was 0 before calling method under test
        Assert.AreEqual(expectedOriginalId, actualOriginalId);
        //verify Save called with correct argument
        //ie: an object that matched the predicate in setup
        mock.Verify();
        // Verify that the IDs are updated for new objects when saved
        Assert.AreEqual(expectedUpdatedId, sut.Id);
    }
