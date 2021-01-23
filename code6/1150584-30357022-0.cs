    [Test]
    public void Policy_TimeoutExpires_DoStuff_TaskShouldNotContinue()
    {
        var cts = new CancellationTokenSource();
        var fakeService = new Mock<IFakeService>();
        IExecutionPolicy policy = new TimeoutPolicy(new ExecutionTimeout(20), new DefaultExecutionPolicy());
        Assert.Throws<AggregateException>(() => policy.ExecuteAsync(() => DoStuff(3000, fakeService.Object), cts.Token).Wait());
    
        fakeService.Verify(f=>f.DoStuff(),Times.Never);
    }
