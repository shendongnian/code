    private Subject<string> _firstName = new Subject<string>();
    private Subject<string> _lastName = new Subject<string>();
    
    private Task<IEnumerable<string>> FetchResults(string firstName, string lastName, CancellationToken cancellationToken)
    {
        // Fetch the results, respecting the cancellation token at the earliest opportunity
        return Task.FromResult(Enumerable.Empty<string>());
    }
    
    private IObservable<IEnumerable<string>> GetResults(string firstName, string lastName)
    {
        return Observable.Create<IEnumerable<string>>(
            async observer =>
            {
                // Use a cancellation disposable to provide a cancellation token the the asynchronous method
                // When the subscription to this observable is disposed, the cancellation token will be cancelled.
                CancellationDisposable disposable = new CancellationDisposable();
                        
                IEnumerable<string> results = await FetchResults(firstName, lastName, disposable.Token);
    
                if (!disposable.IsDisposed)
                {
                    observer.OnNext(results);
                    observer.OnCompleted();
                }
    
                return disposable;
            }
        );
    }
    
    private void UpdateGrid(IEnumerable<string> results)
    {
        // Do whatever
    }
    
    private IDisposable ShouldUpdateGridWhenFirstOrLastNameChanges()
    {
        return Observable
            // Whenever the first or last name changes, create a tuple of the first and last name
            .CombineLatest(_firstName, _lastName, (firstName, lastName) => new { FirstName = firstName, LastName = lastName })
            // Throttle these tuples so we only get a value after it has settled for 100ms
            .Throttle(TimeSpan.FromMilliseconds(100))
            // Select the results as an observable
            .Select(tuple => GetResults(tuple.FirstName, tuple.LastName))
            // Subscribe to the new results and cancel any previous subscription
            .Switch()
            // Use the new results to update the grid
            .Subscribe(UpdateGrid);
    }
