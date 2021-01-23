    public void BeginPasswordReset_SendsEmail()
    {
        const string emailAddress = "email@domain.com";
        ManualResetEvent sendCalled= new ManualResetEvent(false);
        var mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(m => m.Send(emailAddress)).Callback(() =>
        {
            sendCalled.Set();
        });
        var controller = new MyController(mockEmailService.Object);
        controller.BeginPasswordReset(emailAddress);
        Assert.IsTrue(sendCalled.WaitOne(TimeSpan.FromSeconds(3)), "Send was never called");
        mockEmailService.Verify(es => es.Send(emailAddress));
    }
