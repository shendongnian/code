    string queryString = "*[System[Provider[@Name='MyApp'] and (EventID=1 or EventID=2)]]";
    EventLogQuery eventsQuery = new EventLogQuery("Application", PathType.LogName, queryString);
    eventsQuery.ReverseDirection = true;
    eventsQuery.TolerateQueryErrors = true;
    
    try
    {
    	EventLogReader logReader = new EventLogReader(eventsQuery);
    	EventRecord lastLogEntry = logReader.ReadEvent();
    	
    }
    catch (EventLogNotFoundException)
    {
    	Console.WriteLine("Error while reading the event logs");
    	return;
    }
