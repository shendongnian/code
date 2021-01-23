    var observable1 = Observable
        .Create<int>((Func<IObserver<int>, IDisposable>)GenerateSequence)
        .Publish();
    var observable2 = Observable
        .Create<int>((Func<IObserver<int>, IDisposable>)GenerateSequence)
        .Publish();
    var merged = observable1.Merge(observable2);
    observable1.Subscribe(i => Console.WriteLine("1: " + i.ToString()));
    observable2.Subscribe(i => Console.WriteLine("2: " + i.ToString()));
    merged.Subscribe(i => Console.WriteLine("Merged: " + i.ToString()));
    observable1.Connect();
    observable2.Connect();
