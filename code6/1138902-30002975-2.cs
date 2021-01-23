    [TestMethod]
    public void TestGet()
    {
        IHttpActionResult actionResult = controller.Get();
        var contentResult = actionResult as OkNegotiatedContentResult<string>;
        Assert.AreEqual("", contentResult.Content);
    }
