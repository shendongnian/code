    [Test]
    public void MyMethod_WhenGivenAction_ShouldCallAction()
    {
        bool wasCalled = false;
        Util.MyMethod(() => wasCalled = true);
        Assert.That(wasCalled);
    }
