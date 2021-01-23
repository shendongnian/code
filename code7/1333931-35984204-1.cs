	public static class MyFactories {
		public static Func<IEnumerable<T>> CreateListFactory<T>() {
			return () => new List<T>();
		}
	}
    // ... somewhere else
    var myFunc = MyFactories.CreateListFactory<string>();
    var result = myFunc(); // it will be List<string>
