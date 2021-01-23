    string dateString = "2015-07-30 18:00:00.142"
    DateTime parsedDate;
    
    if (DateTime.TryParse(dateString, out parsedDate))
    {
    	// valid
    }
    else 
    {
    	// not valid
    }
