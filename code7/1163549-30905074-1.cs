     IConnectableObservable<int> objGenerator = Observable.Generate(0, i => i < 100, i => i + 1, i => i).Publish();
     IObservable<int, bool> objSelective = objGenerator.ToSelective();
     var objDisposableList = new CompositeDisposable(2) {
        objSelective.Subscribe(i => {
           Console.Write("1");
           if(i % 2 == 0) {
              Console.Write("!");
              return true;
           }
           else {
              Console.Write(".");
              return false;
           }
        }),
        objSelective.Subscribe(i => {
           Console.Write("2");
           Console.Write("!");
           return true;
        })
     };
     objGenerator.Connect();
     objDisposableList.Dispose();
