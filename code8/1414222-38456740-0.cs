    private volatile bool _currentlyRetrievingCahceableData = false;
	public void Caching()
    {
		if (_currentlyRetrievingCahceableData)
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
			_currentlyRetrievingCahceableData = true;
			
            // ...
        }
        catch(Exception error)
        {
            // ...
        }
		finally
		{
			_currentlyRetrievingCahceableData = false;
		}
    }
