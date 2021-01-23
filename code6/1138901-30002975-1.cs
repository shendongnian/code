    [TestMethod]
    public void TestGet()
    {
        IHttpActionResult result = controller.Get();
        var contentResult = actionResult as OkNegotiatedContentResult<string>;
        Assert.AreEqual("", contentResult.Content);
    }
