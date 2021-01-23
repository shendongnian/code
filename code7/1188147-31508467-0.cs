    string query = @
    "*[EventData[Data[@Name='LogonType']='7'] and System[(EventID='4624')]]";
    
    EventLogQuery eventsQuery = new EventLogQuery("Security", PathType.LogName, query);
    
    try {
    	EventLogReader logReader = new EventLogReader(eventsQuery);
    
    	for (EventRecord eventdetail = logReader.ReadEvent(); eventdetail != null; eventdetail = logReader.ReadEvent()) {
    		string description = eventdetail.FormatDescription();
    		string usernametemp = description.Substring(description.IndexOf("Account Name:") + ("Account Name:").Length + 2);
    		string username = usernametemp.Substring(0, usernametemp.IndexOf("\r"));
    	}
    } catch (EventLogNotFoundException) {
    	Console.WriteLine("Error while reading the event logs");
    	return;
    }
