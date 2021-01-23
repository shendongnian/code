    using System;
    using System.Reactive.Linq;
    using Microsoft.Reactive.Testing;
    using NUnit.Framework;
    [TestFixture]
    public class Throttle : ReactiveTest
    {
        private TestScheduler _testScheduler;
        private ITestableObservable<int> _sourceSequence;
        private ITestableObserver<int> _observer;
        [SetUp]
        public void SetUp()
        {
            var windowPeriod = TimeSpan.FromSeconds(5);
            _testScheduler = new TestScheduler();
            _sourceSequence = _testScheduler.CreateColdObservable(
                //Question does the window start when the event starts, or at time 0?
                OnNext(0.1.Seconds(), 1),
                OnNext(1.0.Seconds(), 2),
                OnNext(2.0.Seconds(), 3),
                OnNext(7.0.Seconds(), 4),
                OnCompleted<int>(100.0.Seconds())
                );
            _observer = _testScheduler.CreateObserver<int>();
            _sourceSequence
                .Window(windowPeriod, _testScheduler)
                .SelectMany(window =>
                    window.Publish(
                        shared => shared.Take(1).Concat(shared.Skip(1).TakeLast(1))
                    )
                )
                .Subscribe(_observer);
            _testScheduler.Start();
        }
        [Test]
        public void Should_eagerly_publish_new_events()
        {
            Assert.AreEqual(OnNext(0.1.Seconds(), 1), _observer.Messages[0]);
        }
        [Test]
        public void Should_publish_last_event_of_a_window()
        {
            //OnNext(1.0.Seconds(), 2) is ignored. As OnNext(5.0.Seconds(), 3) occurs after it, and before the end of a window, it is yeiled.
            Assert.AreEqual(OnNext(5.0.Seconds(), 3), _observer.Messages[1]);
        }
        [Test]
        public void Should_only_publish_event_once_if_it_is_the_only_event_for_the_window()
        {
            Assert.AreEqual(OnNext(7.0.Seconds(), 4), _observer.Messages[2]);
            Assert.AreEqual(OnCompleted<int>(100.0.Seconds()), _observer.Messages[3]);
        }
        [Test]
        public void AsOneTest()
        {
            var expected = new[]
            {
                OnNext(0.1.Seconds(), 1),
                //OnNext(1.0.Seconds(), 2) is ignored. As OnNext(5.0.Seconds(), 3) occurs after it, and before the end of a window, it is yeiled.
                OnNext(5.0.Seconds(), 3),
                OnNext(7.0.Seconds(), 4),
                OnCompleted<int>(100.0.Seconds())
            };
            CollectionAssert.AreEqual(expected, _observer.Messages);
        }
    }
