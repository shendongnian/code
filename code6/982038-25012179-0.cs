    using System.Reactive.Linq;
    using System.Reactive.Concurrency;
    var enumerable = Enumerable.Range(10);
    var observable = enumerable.ToObservable();
    var subscription = observable.Subscribe(x => Console.WriteLine(x));
