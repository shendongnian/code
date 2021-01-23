	public class MyRegistry : Registry
	{
		public MyRegistry()
		{
			// The root of the object graph is transient...
			For<IInteractionManager>()
				.Transient()
				.Use<InteractionManager>();
			
			// ...therefore, it can have transient dependencies...
			For<ISubClass>()
				.Transient()
				.Use<SubClass>();
			
			// ...and singleton dependencies.
			For<IMainClass>()
				.Singleton()
				.Use<MainClass>();
		}
	}
