	private EventHandler _myEvent;
		
	public event EventHandler MyEvent
	{
		add
		{
			lock (this)
			{
				_myEvent += value;
			}
		}
		remove
		{
			lock (this)
			{
				_myEvent -= value;
			}
		}        
	}
