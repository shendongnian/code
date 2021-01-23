	DateTime dateTime;
	string str = "2016-02-11 23:02:30";
	if (!DateTime.TryParse(str, out dateTime))
	{
		// error
	}
	
	var serverTimeZone = TimeZoneInfo.Local; // Server time zone
	var allTimeZones = TimeZoneInfo.GetSystemTimeZones(); // Time zone list
	
	TimeZoneInfo clientTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
    // DateTime in server time zone
    var dateTimeZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, clientTimeZone.Id, serverTimeZone.Id);
