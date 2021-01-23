    foreach (var myFruit in response.GetContestResult.ContestEndTimes.ToList())
	{
		// -1 will imply that there is an error.
		int parsedTime = -1;
		
		if (myfruit.ContestantEndTime != null && 
			Int32.TryParse(myfruit.ContestantEndTime, out parsedTime))
		{
			parsedTime /= 60;
		}
	
        htmlResult.AppendFormat("{0} Avg End Time: {1} <br/>", 
			myFruit.ContestantName, 
			parsedTime);
    }
