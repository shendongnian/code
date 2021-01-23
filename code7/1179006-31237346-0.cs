    var observable = Observable.Interval(TimeSpan.FromSeconds(1))
              .Select((x, i) => {
                Foo(x);
                return i;
              })
              .Do(_ => Console.Write("."))
              .Sample(TimeSpan.FromMinutes(1));
    
    observable.Subscribe(x => Console.WriteLine(x));
