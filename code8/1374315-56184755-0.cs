    //The query sort the evenlog so write the characteristics you need
    string query = "*[System/Level=3 or Level=4]";
    /*Select here the eventlog you want to watch, PathType.LogName and also the query you wrote right above*/
    EventLogQuery eventsQuery = new EventLogQuery("System", PathType.LogName, query);
    try
    {
	    EventLogReader logReader = new EventLogReader(eventsQuery);
	    for (EventRecord eventdetail = logReader.ReadEvent(); eventdetail != null; eventdetail = logReader.ReadEvent())
	    {
            //Get the XML for each entry
            /* /!\ eventdetail.ToXml() return a string, that's why you can use string properties*/
		        var doc = eventdetail.ToXml();
            //Select the part of the XML you need
		        int first = doc.IndexOf("<EventData>") + "<EventData>".Length;
		        int last = doc.IndexOf("</EventData>");
		        string finaldoc = doc.Substring(first, last - first);
	  
            //Display the xml before and after selection
		        Console.WriteLine(doc+System.Environment.NewLine);
		        Console.WriteLine(finaldoc);
		        Console.ReadKey();
	   }
    }
	catch (Exception e)
	{
		Console.WriteLine("Error while reading the event logs"+e.Message);
		Console.ReadKey();
    }
                
  
