    using Microsoft.Reactive.Testing;
    using NUnit.Framework;
    using System;
    using System.Reactive.Linq;
    namespace test
    {
        [TestFixture]
        public class PairWithPreviousTests : ReactiveTest
        {
        
            [Test]
            public void Scan2()
            {
                var testScheduler = new TestScheduler();
                var source = new string[] { "a,b", "c,d,e" }.ToObservable();
                var results = testScheduler.Start(
                    () => source.SelectMany(str => str.Split(',')
                        .ToObservable()
                        .Select(x => x.ToUpper())
                        .ToArray()));
                results.Messages.AssertEqual(
                    OnNext<string[]>(Subscribed, new string[] { "A", "B" }),
                    OnNext<string[]>(Subscribed, new string[] { "C", "D", "E" }),
                    OnCompleted<string[]>(Subscribed)
                    );
            }
        }
    }
