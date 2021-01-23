    [TestMethod]
    public async Task TestSearchUserView() {
        //Arrange
        string expected = "SearchUsers";
        var controller = new PlatformUserController();
        //Act
        var actionResult = await controller.SearchUserView();
        //Assert
        Assert.IsNotNull(actionResult);
        var viewResult = actionResult as ViewResult;
        Assert.IsNotNull(viewResult);
        Assert.AreEqual(expected, viewResult.ViewName);  
    } 
