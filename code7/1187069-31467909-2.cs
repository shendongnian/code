	public class Factory
	{
		private Dictionary<Type, Delegate> _factories = new Dictionary<Type, Delegate>();
		
		public T Build<T>(string name)
		{
			return ((Func<string, T>)_factories[typeof(T)])(name);
		}
		
		public void Define<T>(Func<string, T> create)
		{
			_factories.Add(typeof(T), create);
		}
	}
