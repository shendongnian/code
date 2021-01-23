    DateTime startDateTime;
	DateTime.TryParse("2016-08-25 15:00:00", out startDateTime);
	DateTime endDateTime; 
	DateTime.TryParse("2016-08-27 15:28:30", out endDateTime);
	TimeSpan span = (endDateTime - startDateTime);
	
    string.Format("{0}:{1}:{2}", (int)span.TotalHours, span.Minutes, span.Seconds);	
