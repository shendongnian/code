    [TestMethod]
    public void ScheduleTransportOrder_1()
    {
        communicationService = new CommunicationService(new FakeDbContext());
        communicationService.SomeMethodThatUsesIContext();
        Assert.IsTrue(...) // file should be created.
    }
