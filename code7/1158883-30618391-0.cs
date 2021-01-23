    [TestMethod] 
    public async Task SendRegionsEnrollmentMessages() 
    { 
        EventManager eventMgr = new EventManager(clientUrn, programUrn, "CW"); 
        await eventMgr.SendBatchEvents(EventType.ENROLLMENT); 
    }
