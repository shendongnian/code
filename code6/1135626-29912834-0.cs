	private string GetQuarterDisplay(DateTime dateKey)
    {
		var availabilityDS = (AvailabilityDS.IntelTimeRow[])mAvailabilityDS
		if(availabilityDS != null) 
		{
			var time = availabilityDS.Time;
			if(time != null) 
			{
				var elements = availabilityDS.Select('"+ dateKey + "'");
				if(elements.Any()) 
				{
					return elements[0].QuarterDisplay;
				}
			}
		}
		return null;
    }
     
