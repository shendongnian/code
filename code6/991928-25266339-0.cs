    Subject<string> subject = new Subject<string>();
    IObservable<string> searchString = subject;
    searchString
             .Buffer(TimeSpan.FromMillisecond(300))
             .Select(searchString => 
                    Observable.StartAsync(cancelToken => 
                          Search(searchString, cancelToken)
                    ).Switch()
             .ObserveOn(someUiScheduler)
             .Subscribe(results => UpdateUi(results));
    subject.OnNext("Search Term");
