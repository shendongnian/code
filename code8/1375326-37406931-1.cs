	private static DateTime ToSeoulTime(DateTime dateUtc, bool ignoreUnspecified = false)
	{
		if (ignoreUnspecified == false && dateUtc.Kind == DateTimeKind.Unspecified)
		{
			if (UnityEngine.Application.isEditor)
			{
				throw new Exception("dateUtc.Kind == DateTimeKind.Unspecified");
			}
			else
			{
				UnityEngine.Debug.LogWarning("dateUtc.Kind == DateTimeKind.Unspecified");
			}
		}
		try
		{
			var seoulTimezone = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
			return TimeZoneInfo.ConvertTime(dateUtc, seoulTimezone);
		}
		catch (System.TimeZoneNotFoundException e)
		{
			return new DateTime(dateUtc.AddHours(9).Ticks, DateTimeKind.Unspecified);
		}
	}
	
