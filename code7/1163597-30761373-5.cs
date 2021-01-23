    private const int _THROTTLE = 50;
    private const int _TIMEOUT = 100;
    private const int _COMPLETE = 100000;
    [TestCase("groupby", new[] { 1, 10 }, new[] { 10 }, new[] { 10 + _THROTTLE }, TestName = "g1")]
    [TestCase("groupby", new[] { 1, 10, 40, 60 }, new[] { 60 }, new[] { 1 + _TIMEOUT }, TestName = "g2")]
    [TestCase("groupby", new[] { 1, 45, 1000, 1040, 1080, 1110, }, new[] { 45, 1080, 1110 }, new[] { 45 + _THROTTLE, 1000 + _TIMEOUT, 1110 + _THROTTLE }, TestName = "g3")]
    [TestCase("window", new[] { 1, 10 }, new[] { 10 }, new[] { 10 + _THROTTLE }, TestName = "w1")]
    [TestCase("window", new[] { 1, 10, 40, 60 }, new[] { 60 }, new[] { 1 + _TIMEOUT }, TestName = "w2")]
    [TestCase("window", new[] { 1, 45, 1000, 1040, 1080, 1110, }, new[] { 45, 1080, 1110 }, new[] { 45 + _THROTTLE, 1000 + _TIMEOUT, 1110 + _THROTTLE }, TestName = "w3")]
    public void Throttle(string which, int[] pattern, int[] expectedPattern, int[] expectedTimes)
    {
        var scheduler = new TestScheduler();
        var completeEvent = new[] { ReactiveTest.OnCompleted(_COMPLETE, _COMPLETE) };
        var source = scheduler.CreateColdObservable(pattern.Select(v => ReactiveTest.OnNext(v, v)).Concat(completeEvent).ToArray());
        var throttled = source.ThrottleWithMax(which, TimeSpan.FromTicks(_THROTTLE), TimeSpan.FromTicks(_TIMEOUT), scheduler);
        var observer = scheduler.CreateObserver<int>();
        throttled.Subscribe(observer);
        
        // start the clock
        scheduler.Start();
        
        // check the results
        var expected = expectedPattern.Zip(expectedTimes, (v, t) => ReactiveTest.OnNext(t, v)).Concat(completeEvent).ToList();
        CollectionAssert.AreEqual(expected, observer.Messages);
    }
