    [TestMethod]
    public void TestFirstPageType()
    {
        Wizard testWizard = new Wizard();
        Mock<IContainer> mockContainer = new Mock<IContainer>();
        mockContainer.Setup(c => c.GetInstance<FirstStepView>()).Returns(new FirstStepView());
        testWizard.IOCContainer = mockContainer.Object;
        testWizard.Initialize();
        FirstStepView testView = testWizard.CurrentStep as FirstStepView;
        Assert.IsTrue(testView != null);
    }
