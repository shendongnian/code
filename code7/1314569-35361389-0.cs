    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Threading;
    
    class Program
    {
        static void Main(string[] args)
        {
            var instance = ThreadPoolScheduler.Instance;
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
    
            var disposable = Observable
                .Interval(TimeSpan.FromSeconds(0.5), instance)
                .Subscribe(_ => Console.WriteLine(DateTime.UtcNow));
            cts.Token.Register(() => disposable.Dispose());
            Thread.Sleep(10000);
        }
    }
