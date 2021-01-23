    private HandlerDelegateType _privateDelegate;
	
	public event HandlerDelegateType PublicEvent
	{
		add
		{
			_privateDelegate += value;
			
		}
		remove
		{
			_privateDelegate-= value;
            if(_privateDelegate == null)
            {
                // Can perform some other action here
                // For example, unsubscribe from a second event source
            }
		}
	}
