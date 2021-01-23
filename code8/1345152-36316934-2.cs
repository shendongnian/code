		public interface IClock
		{
			DateTimeOffset Now { get; }
			DateTimeOffset UtcNow { get; }
		}
		
		internal class Clock : IClock
		{
			public DateTimeOffset Now => DateTimeOffset.Now;
			public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
		}
		
	In your tests, you just mock the interface as you wish.
 
