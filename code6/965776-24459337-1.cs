    [TestCase(true)]
    [TestCase(false)]
    public void MyTest_with_TestObservers(bool expected)
    {
        var observer = new TestScheduler().CreateObserver<bool>();
        var x = new Subject<bool>();
        x.Subscribe(observer);
        x.OnNext(expected);
        observer.Messages.AssertEqual(
            OnNext(0, expected));
    }
