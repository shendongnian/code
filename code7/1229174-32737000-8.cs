	public class MyRegistry : Registry
	{
		public MyRegistry()
		{
			// Register all types
			this.For<ISomeService>().Use<SomeService>();
		}
	}
