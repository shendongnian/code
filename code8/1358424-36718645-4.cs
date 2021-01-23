	DateTime dateTime;
	string str = "2016-02-11 23:02:30 -0500";
	if (!DateTime.TryParse(str, out dateTime))
	{
		// error
	}
	
    dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
	var serverTimeZone = TimeZoneInfo.Local; // Server time zone
	var allTimeZones = TimeZoneInfo.GetSystemTimeZones(); // Time zone list
	
	var clientTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
    // DateTime in server time zone
    var dateTimeZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, clientTimeZone.Id, serverTimeZone.Id);
