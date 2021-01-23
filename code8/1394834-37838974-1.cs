    [Setup]
    public void SetUp () 
    {
        var controller = new ControllerTestable();
        //...
    }
    [Test]
    public void Can_Open_SomeAction()
    {
        // controller is already set inside `SetUp` unit step.
        ViewResult res = this.controller.SomeAction() as ViewResult;
        var model = result.Model as JobCreate;
                
        //...
        Assert.IsTrue(controller.IsCalled);
        Assert.IsNotNull(model);
    }
