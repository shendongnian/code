    public class ScopeFinalizer : IDisposable
    {
        private Action delayedFinalization;
        public ScopeFinalizer(Action delayedFinalization)
        {
            this.delayedFinalization = delayedFinalization ?? throw new ArgumentNullException(nameof(delayedFinalization));
        }
        public void Dispose()
        {
            delayedFinalization();
        }
    }
	//usage example
    public async Task<bool> DoWorkAsyncShowingProgress()
    {
    	ShowActivityIndicator();
        using var _ = new ScopeFinalizer(() =>
        {
            // --> Do work you need at enclosure scope leaving <--
            HideActivityIndicator();
        });
        var result = await DoWorkAsync();
        HandleResult(result);
        //etc ...
        return true;
    }
