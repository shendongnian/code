    Instant now = SystemClock.Instance.Now;
    IDateTimeZoneProvider timeZoneProvider = DateTimeZoneProviders.Tzdb;
    Dictionary<TimeSpan, List<string>> timezonesForOffset = new Dictionary<TimeSpan, List<string>>();
    foreach(var id in timeZoneProvider.Ids){
    	ZonedDateTime zdt = now.InZone(timeZoneProvider[id]);
    	var timespan = zdt.Offset.ToTimeSpan();
    	if(timezonesForOffset.ContainsKey(timespan)){
    		timezonesForOffset[timespan].Add(id);
    	} else {
    		timezonesForOffset[timespan] = new List<string> {id, };
    	}
    }
