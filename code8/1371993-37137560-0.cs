    async void PopulateTableWithData()
    {
    	var service = new Data.RestService();
    	var response = await service.GetEventItemsAsync();
    
    	Debug.WriteLine("JSON RESULTS FOUND: " + response.Count + "events");
    
    	//listView.ItemsSource = response; // Display data in listview
    
    	//Instantiate the list of upcoming events before the loop
    	List<EventItems> upcomingEvents = new List<EventItems>();
    	for(int i = 0; i < response.Count; i++)
    	{
    		// Split raw json date
    		string[] splitRawDateTime = response[i].EventEndTime.Split('T');
    		string[] splitRawDate = splitRawDateTime[0].Split('-');
    
    
    		string eventYear = splitRawDate[0];
    		string eventMonth = splitRawDate[1];
    		string eventDay = splitRawDate[2];
    
    		// Compare dates and display events according to date
    		DateTime currentDateTime = DateTime.Now;
    		DateTime eventDateTime = new DateTime(int.Parse(eventYear), int.Parse(eventMonth), int.Parse(eventDay), 0, 0, 0);
    
    		int compareDates = DateTime.Compare(eventDateTime, currentDateTime);
    
    		if (compareDates < 0)
    		{
    			Debug.WriteLine("Event date {0} is earlier then current date {1}", eventDateTime, currentDateTime);
    		}
    		else
    		{
    			Debug.WriteLine("Event date {0} is later then current date {1}", eventDateTime, currentDateTime);
    
    			//Populate the list of upcoming events
    			upcomingEvents.Add(response[i]);
    		}
    	}
    	//Display the list of upcoming events
    	listView.ItemsSource = upcomingEvents;
    }
