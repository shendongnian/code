    [TestMethod]
    public void TestCheckRightsWithoutRights()
    {
        MyService service = ...
        service.When(svc => svc.Exit()).DoNotCallBase();
        ...
        service.CheckRights();
        service.Received(1).Exit();
    }
