    [Test]
    public void Test()
    {
        var testScheduler = new TestScheduler();
        var o = Observable
            .Defer(() => Observable
                .Start(() => { throw new InvalidOperationException(); }, testScheduler)
                .PublishLast()
                .ConnectUntilCompleted());
        var observer = testScheduler.CreateObserver<Unit>();
        o.Subscribe(observer);
        testScheduler.Start();
        CollectionAssert.IsNotEmpty(observer.Messages);
        Assert.AreEqual(NotificationKind.OnError, observer.Messages[0].Value.Kind);
    }
