		public static bool IsCreated { get; private set; } // default false
		public static IFoo GetInstance()
		{
			IsCreated = true;
			// return the Singleton Instance of IFoo
		}
	}
