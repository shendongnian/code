    [Test]
    public void ChildActionNotInvokedAsChildAction()
    {
        var action = new TestController()
            .Action(c => c.Update());
        action.GetActionResult().Should().BeOfType<RedirectToRouteResult>();
    }
    [Test]
    public void ChildActionInvokedAsChildAction()
    {
        var action = new TestController()
            .ChildAction(c => c.Update());
        action.GetActionResult().Should().BeOfType<PartialViewResult>();
    }
