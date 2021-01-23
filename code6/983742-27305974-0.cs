    using Xania.AspNet.Simulator;
    .....
    
    [Test]
    public void CustomFilterProviderTest()
    {
        // arrange
        var action = new AccountController().Action(c => c.ChangePassword(null));
        action.FilterProviders.Add(new CustomFilterProvider());
        // act
        var result = action.Execute();
        // assert
        Assert.AreEqual("Your Message", result.ViewBag.Message);
        Assert.IsTrue(result.ModelState.IsValid);
        Assert.IsInstanceOf<ViewResult>(result.ActionResult);
        ...
    }
