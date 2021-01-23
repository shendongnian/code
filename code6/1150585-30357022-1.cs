    [Test]
    public async Task Policy_TimeoutExpires_DoStuff_TaskShouldNotContinue()
    {
        var cts = new CancellationTokenSource();
        var fakeService = new Mock<IFakeService>();
        IExecutionPolicy policy = new TimeoutPolicy(new ExecutionTimeout(20), new DefaultExecutionPolicy());
        try
        {
            await policy.ExecuteAsync(() => DoStuff(3000, fakeService.Object), cts.Token);
            Assert.Fail("Method did not timeout.");
        }
        catch (TimeoutException)
        { }
    
        fakeService.Verify(f=>f.DoStuff(),Times.Never);
    }
