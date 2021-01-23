	private volatile bool _stopping;
	private void ThreadWork()
	{
		while (!_stopping)
		{
			Reload();
			Thread.Sleep(INTERVAL);
		}
	}
	public void Stop()
	{
		_stopping = true;
	}
