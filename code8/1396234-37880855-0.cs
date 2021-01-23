    [TestMethod]
    public async Task TestSearchUserView() {
        string expected = "SearchUserView";
        var  controller = new PlatformUserController();
        var actionResult = await controller.SearchUserView();
        var viewResult = actionResult as ViewResult;
        Assert.IsNotNull(viewResult);
        Assert.AreEqual("SearchUserView", viewResult.ViewName);  
    } 
