    var obs = Observable.Create<IObservable<int>>(sub =>
    {
	   var item = Observable.Create<int>(innersub =>
	   {
		   var count = 0;
		   return Observable.Interval(TimeSpan.FromSeconds(2))
                            .Subscribe(x => innersub.OnNext(count++));
	   }).Publish();
	   bool connected = false;
	   var disposables = new CompositeDisposable();
	   disposables.Add(Observable.Interval(TimeSpan.FromSeconds(10))
								 .Subscribe(x =>
								 {
									 // push the new stream to the observer first
									 sub.OnNext(item);
									 if (!connected)
									 {
									 	 connected = true;
										 disposables.Add(item.Connect());
									 }
								 }));
	   return disposables;
    });
