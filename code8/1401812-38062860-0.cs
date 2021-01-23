    public void Save_NewObjects_IdsUpdated() {
        //Arrange
        var mock = new Mock<IPersistence>();
        mock.Setup(x => x.Save(It.IsAny<Class1>()))
            .Returns((Class1 c) => {
                // If it is a new object, then update the ID
                if (c.Id == 0) c.Id = 1;
                return c;
            });        
        var sut = new Class1(mock.Object);
        var originalId = sut.Id;
        //Act
        sut.Save();
        //Assert
        Assert.AreEqual(0, originalId);
        mock.Verify(x => x.Save(sut));
        // Verify that the IDs are updated for new objects when saved
        Assert.AreEqual(1, sut.Id);
    }
