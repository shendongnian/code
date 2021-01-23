		public static class Clock
		{
			internal static Func<DateTimeOffset> DateTimeOffsetProvider { get; set; }
				= () => DateTimeOffset.Now;
			
			public static DateTimeOffset Now => DateTimeOffsetProvider();
			public static DateTimeOffset UtcNow => DateTimeOffsetProvider().ToUniversalTime();
		}
		
	In your tests, you can substitute `DateTimeOffsetProvider`.
