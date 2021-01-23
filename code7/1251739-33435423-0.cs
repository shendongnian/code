    private void RegisterEvent(object obj, string eventName)
    {
    	Type type = obj.GetType();
    	EventInfo @event = type.GetEvent(eventName);
    	if (@event == null)
    	{
    		if (this.SourceObject != null)
    		{
    			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ExceptionStringTable.EventTriggerCannotFindEventNameExceptionMessage, new object[]
    			{
    				eventName,
    				obj.GetType().Name
    			}));
    		}
    		return;
    	}
    	/* and so on... */
    }
