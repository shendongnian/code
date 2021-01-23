	public class Factory
	{
		private ILogger _logger; //get logger something else.
	
		public Factory()
		{
			_factories = new Dictionary<Type, Func<Type, object>>()
			{
				{ typeof(ILogger), t => _logger },
			};
		}
	
		private Dictionary<Type, Func<Type, object>> _factories;
	
		public T GetService<T>()
		{
			var t = typeof(T);
			return (T)_factories[t].Invoke(t);
		}
	}
