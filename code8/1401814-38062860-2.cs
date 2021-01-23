    [Test]
    public void Save_NewObjects_IdsUpdated() {
        //Arrange
        var mock = new Mock<IPersistence>();
        mock.Setup(x => x.Save(It.Is<Class1>(o => o.Id == 0)))
            .Returns((Class1 c) => {
                // If it is a new object, then update the ID
                if (c.Id == 0) c.Id = 1;
                return c;
            }).Verifiable();
        var sut = new Class1(mock.Object);
        
        //Act
        sut.Save();
        //Assert
        //verify Save called with correct argument
        mock.Verify();
        // Verify that the IDs are updated for new objects when saved
        Assert.AreEqual(1, sut.Id);
    }
