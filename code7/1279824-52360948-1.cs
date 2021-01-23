        private readonly SemaphoreSlim _RefreshLock = new SemaphoreSlim(1);
     	public virtual async Task RefreshAsync()
        {
            try
            {
                await _RefreshLock.WaitAsync();
		        //Your work here
            }
            finally
            {
                _RefreshLock.Release();
            }
        }
