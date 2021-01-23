    // Constructor
    public SearchViewModel(ISearchService searchService = null)
    {
        SearchService = searchService ?? Locator.Current.GetService<ISearchService>();
     
        // Here we're describing here, in a *declarative way*, the conditions in
        // which the Search command is enabled.  Now our Command IsEnabled is
        // perfectly efficient, because we're only updating the UI in the scenario
        // when it should change.
        var canSearch = this.WhenAny(x => x.SearchQuery, x => !String.IsNullOrWhiteSpace(x.Value));
     
        // ReactiveCommand has built-in support for background operations and
        // guarantees that this block will only run exactly once at a time, and
        // that the CanExecute will auto-disable and that property IsExecuting will
        // be set according whilst it is running.
        Search = ReactiveCommand.CreateAsyncTask(canSearch, async _ => {
            return await searchService.Search(this.SearchQuery);
        });
     
        // ReactiveCommands are themselves IObservables, whose value are the results
        // from the async method, guaranteed to arrive on the UI thread. We're going
        // to take the list of search results that the background operation loaded,
        // and them into our SearchResults.
        Search.Subscribe(results => {
            SearchResults.Clear();
            SearchResults.AddRange(results);
        });
     
        // ThrownExceptions is any exception thrown from the CreateAsyncTask piped
        // to this Observable. Subscribing to this allows you to handle errors on
        // the UI thread.
        Search.ThrownExceptions
            .Subscribe(ex => {
                UserError.Throw("Potential Network Connectivity Error", ex);
            });
     
        // Whenever the Search query changes, we're going to wait for one second
        // of "dead airtime", then automatically invoke the subscribe command.
        this.WhenAnyValue(x => x.SearchQuery)
            .Throttle(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
            .InvokeCommand(this, x => x.Search);
    }
