    [Test]
    public void Can_Open_SomeAction()
    {
        // controller is already set inside `SetUp` unit step.
        var populatePageHelperMock = new Mock<PopulatePageCombosHelper>();
        controller.populatePageHelper = populatePageHelperMock;
        ViewResult res = this.controller.SomeAction() as ViewResult;
        var model = result.Model as JobCreate;
        
        //...
        Assert.IsNotNull(model);
    }
