    public static IObservable<Foo> WrapFooApi(string arg1, string arg2)
    {
        return Observable.Create<Foo>(observer =>
        {
            var disposable = new BooleanDisposable();
            FooApi.enumerate(arg1, arg2, e =>
            {
                observer.OnNext(new Foo(e));
                // Returning false will stop the enumeration
                return !disposable.IsDisposed;
            });
            // In your case, FooApi.enumerate is actually synchronous
            // so when we get to this line of code, we know
            // the stream is complete.
            observer.OnCompleted();
            // will get disposed if the observer unsubscribes
            return disposable;
        });
    }
    // Usage
    WrapFooApi("a", "b").Take(1).Subscribe(...); // only takes first item
