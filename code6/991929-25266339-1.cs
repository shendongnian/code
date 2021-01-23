    IDisposable _searchSubscriber =
        _searchString
             .Buffer(TimeSpan.FromMillisecond(300))
             .Select(searchString => 
                    Observable.StartAsync(cancelToken => 
                          Search(searchString, cancelToken)
                    ).Switch()
             .ObserveOn(new DispatcherScheduler())
             .Subscribe(results => Channels = results);
    private BehaviorSubject<string> _searchString = new BehaviorSubject<string>("");
    public string SearchString
    {
        get { return _searchString.Value; }
        set { _searchString.OnNext(value); OnPropertyChanged("SearchString"); }
    }
