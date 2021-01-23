		private Dictionary<string, object> Properties = new Dictionary<string, object>();
		public T Get<T>([CallerMemberName] string propertyName = null)
		{
			if (!Properties.ContainsKey(propertyName))
				Properties[propertyName] = default(T);
			return (T)Properties[propertyName];
		}
		public void Set<T>(T value, [CallerMemberName] string propertyName = null)
		{
			Properties[propertyName] = value;
			RaisePropertyChanged(propertyName);
		}
