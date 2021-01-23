	static class Factory
	{
		private static Dictionary<int, Func<Position>> _registry =
			new Dictionary<int, Func<Position>>();
	
		public static void Register(int id, Func<Position> factory)
		{
			_registry[id] = factory;
		}
	
		public static Position Get(int id)
		{
			return _registry[id].Invoke();
		}
	}
