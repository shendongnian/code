	public static class Extensions
	{
		public static DateTime ToCleanDateTime(this DateTime dt)
		{
		  return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);      
		}
		public static DateTime? ToCleanDateTime(this DateTime? dt)
		{
			if (dt.HasValue)
			{
				return dt.Value.ToCleanDateTime();
			}
			return dt;
		}
	}
