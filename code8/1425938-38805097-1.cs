    [Test]
    public void Get_Check_That_Id1_Returns_Crossing() {
        //Arrange
        var id = 1;
        _attribsRepositoryMock.Setup(t => t.GetAttrib(id)).Returns(AttribList[0]);
        var attribsController = new AttribsController(_attribsRepositoryMock.Object);
        //Act
        var result = attribsController.GetAttrib(id) as OkNegotiatedContentResult<Attrib>;
        //Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Content);
        Assert.AreEqual(result.Content.AttributeName, "Crossing");
    }
