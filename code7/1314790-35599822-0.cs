    [TestMethod, ExpectedException(typeof(ProgramException))]
    public void MyMethod_WhenEmptyBody_ThrowsException()
    {
        // Arrange 
        var emptyBody = "";
        var getBodyMock = new Mock<ICanGetHttpBodies>()
            .Setup(m => m.AsString(It.IsAny<Uri>())
            .Returns(emptyBody);
        // Act & Assert
    }
