    IDisposable _searchSubscriber =
        _searchString
             .Buffer(TimeSpan.FromMillisecond(300))
             .Select(searchString => 
                    Observable.StartAsync(cancelToken => 
                          Search(searchString, cancelToken)
                    ).Switch()
             .ObserveOn(new DispatcherScheduler())
             .Subscribe(results => Channels = results);
    public Task<List<Channel>> Search(string searchTerm, CancellationToken cancel)
    {
        var query = dbContext.Channels.Where(x => x.Name.StartsWith(searchTerm));
        return query.ToListAsync(cancel);
    }
    private BehaviorSubject<string> _searchString = new BehaviorSubject<string>("");
    public string SearchString
    {
        get { return _searchString.Value; }
        set { _searchString.OnNext(value); OnPropertyChanged("SearchString"); }
    }
