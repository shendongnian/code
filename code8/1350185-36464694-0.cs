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
			public static DateTime OrIfLater(this DateTime a, DateTime b)
			{
				return a.ToUniversalTime().Ticks > b.ToUniversalTime().Ticks ? a : b;
			}
		}
		[..]
	}
