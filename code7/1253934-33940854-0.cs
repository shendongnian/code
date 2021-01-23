    public static void subscribe()
    {
    	EventLogWatcher watcher = null;
    	try
    	{
    		EventLogQuery subscriptionQuery = new EventLogQuery(
			    "Security", PathType.LogName, "*[System/EventID=4624]");
    
    		watcher = new EventLogWatcher(subscriptionQuery);
    
    		// Make the watcher listen to the EventRecordWritten
    		// events.  When this event happens, the callback method
    		// (EventLogEventRead) is called.
    		watcher.EventRecordWritten +=
    			new EventHandler<EventRecordWrittenEventArgs>(
    				EventLogEventRead);
    
    		// Activate the subscription
    		watcher.Enabled = true;
    
    		for (int i = 0; i < 5; i++)
    		{
    			// Wait for events to occur. 
    			System.Threading.Thread.Sleep(10000);
    		}
    	}
    	catch (EventLogReadingException e)
    	{
    		Log("Error reading the log: {0}", e.Message);
    	}
    	finally
    	{
    		// Stop listening to events
    		watcher.Enabled = false;
    
    		if (watcher != null)
    		{
    			watcher.Dispose();
    		}
    	}
    	Console.ReadKey();
    }
    // Callback method that gets executed when an event is
    // reported to the subscription.
    public static void EventLogEventRead(object obj,
    	EventRecordWrittenEventArgs arg)
    {
    	// Make sure there was no error reading the event.
    	if (arg.EventRecord != null)
    	{
    		//////
    		// This section creates a list of XPath reference strings to select
    		// the properties that we want to display
    		// In this example, we will extract the User, TimeCreated, EventID and EventRecordID
    		//////
    		// Array of strings containing XPath references
    		String[] xPathRefs = new String[9];
    		xPathRefs[0] = "Event/System/TimeCreated/@SystemTime";
    		xPathRefs[1] = "Event/System/Computer";
    		xPathRefs[2] = "Event/EventData/Data[@Name=\"TargetUserName\"]";
    		xPathRefs[3] = "Event/EventData/Data[@Name=\"TargetDomainName\"]";
    		// Place those strings in an IEnumberable object
    		IEnumerable<String> xPathEnum = xPathRefs;
    		// Create the property selection context using the XPath reference
    		EventLogPropertySelector logPropertyContext = new EventLogPropertySelector(xPathEnum);
    
    		IList<object> logEventProps = ((EventLogRecord)arg.EventRecord).GetPropertyValues(logPropertyContext);
    		Log("Time: ", logEventProps[0]);
    		Log("Computer: ", logEventProps[1]);
    		Log("TargetUserName: ", logEventProps[2]);
    		Log("TargetDomainName: ", logEventProps[3]);
    		Log("---------------------------------------");
    
    		Log("Description: ", arg.EventRecord.FormatDescription());
    	}
    	else
    	{
    		Log("The event instance was null.");
    	}
    }
