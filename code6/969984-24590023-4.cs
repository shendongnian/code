	namespace LaF.ExtensionMethods
	{
		public static class MyExtensions
		{
			public static string TimeSpanToString(this TimeSpan ts)
			{
				return ts.ToString(@"hh\:mm");
			}
		}
	}
