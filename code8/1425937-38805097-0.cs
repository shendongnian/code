    [Test]
    public void Get_Check_That_Id1_Returns_Crossing()
    {
        //Arrange
        _attribsRepositoryMock.Setup(t => t.GetAttrib(1)).Returns(AttribList[0]);
        var attribsController = new AttribsController(_attribsRepositoryMock.Object);
        //Act
        var result = attribsController.GetAttrib(1) as OkNegotiatedContentResult<Attrib>;
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Content.AttributeName, "Crossing");
    }
