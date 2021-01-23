    [TestMethod]
    public void ScheduleTransportOrder_1()
    {
        var testKernel = new StandardKernel(new FakeNinjectConfig ());
        communicationService = testKernel.Get<CommunicationService>();
        communicationService.SomeMethodThatUsesIContext();
        Assert.IsTrue(...) // file should be created.
    }
