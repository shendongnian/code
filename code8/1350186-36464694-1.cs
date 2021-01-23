	namespace Stuff
	{
		public static class DynamicHelper
		{
			/// <summary>
			/// returns the latest date/time of the two, based on universal time
			/// </summary>
			/// <param name="a">this timestamp</param>
			/// <param name="b">the parameter timestamp to compare with</param>
			/// <example>var latest = yesterday.OrIfLater(today);</example>
			/// <returns>the most recent of the two timestamps</returns>
			public static DateTimeOffset OrIfLater(this DateTimeOffset a, DateTimeOffset b)
			{
				return a.UtcTicks > b.UtcTicks ? a : b;
			}
		}
		[..]
	}
