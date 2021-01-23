    private DataProviderResult FetchNextResult()
    {
        // let exceptions throw
        return dataProvider.GetInformation().ToList();
    }
    private IObservable<DataProviderResult> CreateObservable(IScheduler scheduler)
    {
        // an observable that produces a single result then completes
        var fetch = Observable.Defer(
            () => Observable.Return(FetchNextResult));
        // concatenate this observable with one that will pause
        // for "tok" time before completing.
        // This observable will send the result
        // then pause before completing.
        var fetchThenPause = fetch.Concat(Observable
            .Empty<DataProviderResult>()
            .Delay(tok, scheduler));
        // Now, if fetchThenPause fails, we want to consume/ignore the exception
        // and then pause for tnotok time before completing with no results
        var fetchPauseOnErrors = fetchThenPause.Catch(Observable
            .Empty<DataProviderResult>()
            .Delay(tnotok, scheduler));
        // Now, whenever our observable completes (after its pause), start it again.
        var fetchLoop = fetchPauseOnErrors.Repeat();
        // Now use Publish(initialValue) so that we remember the most recent value
        var fetchLoopWithMemory = fetchLoop.Publish(null);
        // YMMV from here on.  Lets use RefCount() to start the
        // connection the first time someone subscribes
        var fetchLoopAuto = fetchLoopWithMemory.RefCount();
        // And lets filter out that first null that will arrive before
        // we ever get the first result from the data provider
        return fetchLoopAuto.Where(t => t != null);
    }
    public MyClass()
    {
        Information = CreateObservable();
    }
    public IObservable<DataProviderResult> Information { get; private set; }
