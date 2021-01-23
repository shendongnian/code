    private static bool _currentlyRetrievingCacheableData = false;
	public void Caching()
    {
		if (_currentlyRetrievingCacheableData)
		{
			return;
		}
		
        Thread worker = new Thread(() => CacheWorker());
        worker.Start();
    }
    public void CacheWorker()
    {
        try
        {
			_currentlyRetrievingCacheableData = true;
			
            // ...
        }
        catch(Exception error)
        {
            // ...
        }
		finally
		{
			_currentlyRetrievingCacheableData = false;
		}
    }
