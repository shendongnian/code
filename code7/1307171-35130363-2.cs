	class ObjectStore
	{
		private readonly Dictionary<string, object> _objects = new Dictionary<string, object>();'
		
		public void Add(string key, object obj)
		{
			_objects[key] = obj;
		}
		
		public object Get<T>(string key)
		{
			object obj;
			if(_objects.TryGetValue(key, out obj))
			{
				return (T)obj;
			}
			
			return default(T);
		}
		
		public object this[string key]
		{
			get { return _objects[key]; }
			set { _objects[key] = value; }
		}
	}
