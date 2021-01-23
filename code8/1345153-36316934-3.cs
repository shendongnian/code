		public static class Clock
		{
			internal static Func<DateTimeOffset> DateTimeOffsetProvider { get; set; }
				= () => DateTimeOffset.Now;
			
			public static DateTimeOffset Now => DateTimeOffsetProvider();
			public static DateTimeOffset UtcNow => DateTimeOffsetProvider().ToUniversalTime();
		}
		
	In your tests, you can substitute `DateTimeOffsetProvider`.
	
	Here's a .NET 2 version:
	
		public static class Clock
		{
			internal delegate DateTimeOffset DateTimeOffsetProviderDelegate();
			internal static DateTimeOffsetProviderDelegate DateTimeOffsetProvider { get; set; }
			
			public static DateTimeOffset Now { get { return DateTimeOffsetProvider(); } }
			public static DateTimeOffset UtcNow { get { return DateTimeOffsetProvider().ToUniversalTime(); } }
			
			static Clock()
			{
				DateTimeOffsetProvider = delegate() { return DateTimeOffset.Now; };
			}
		}
