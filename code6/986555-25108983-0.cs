    public class MyTests : ReactiveTest
    {
        [Fact]
        public void Should_only_contain_most_recent()
        {
            var scheduler = new TestScheduler();
            var source = scheduler.CreateHotObservable(
                OnNext(0, 1),
                OnNext(0, 2),
                OnNext(TimeSpan.FromMilliseconds(50).Ticks, 3),
                OnNext(TimeSpan.FromMilliseconds(100).Ticks, 4),
                OnNext(TimeSpan.FromMilliseconds(300).Ticks, 5),
                OnCompleted(TimeSpan.FromMilliseconds(300).Ticks, witness: 0));
            var replaySubject = new ReplaySubject<int>(
                TimeSpan.FromMilliseconds(200), scheduler);
            source.Subscribe(replaySubject);
            scheduler.Start();
            /* the test scheduler is now at 300 milliseconds
                * and the ReplaySubject is loaded */
            Console.WriteLine(scheduler.Now.Ticks);
            var results = scheduler.CreateObserver<int>();
            replaySubject.Subscribe(results);
            /* run the scheduler on to flush the events from the ReplaySubject */
            scheduler.Start();
            results.Messages.AssertEqual(
                OnNext(TimeSpan.FromMilliseconds(300).Ticks + 1, 4),
                OnNext(TimeSpan.FromMilliseconds(300).Ticks + 2, 5),
                OnCompleted(TimeSpan.FromMilliseconds(300).Ticks + 3, witness: 0));
        }
    }
