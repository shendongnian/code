    [TestMethod]
    public async Task TestSearchUserView() {
        //Arrange
        string expected = "SearchUserView";
        var controller = new PlatformUserController();
        //Act
        var actionResult = await controller.SearchUserView();
        var viewResult = actionResult as ViewResult;
        //Assert
        Assert.IsNotNull(viewResult);
        Assert.AreEqual("SearchUserView", viewResult.ViewName);  
    } 
