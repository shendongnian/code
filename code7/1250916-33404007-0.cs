	public class Range
	{
		private static Dictionary<Type, Delegate> _factories = new Dictionary<Type, Delegate>();
	
		public static void AddFactory<T>(Func<T, T, Range<T>> factory) where T : IComparable<T>
		{
			_factories.Add(typeof(T), factory);
		}
	
		public static Range<T> Create<T>(T bound1, T bound2) where T : IComparable<T>
		{
			Func<T, T, Range<T>> factory =
				_factories.ContainsKey(typeof(T))
					? (Func<T, T, Range<T>>)_factories[typeof(T)]
					: (Func<T, T, Range<T>>)((n, x) => new Range<T>()
					{
						Minimum = bound1,
						Maximum = bound2
					});
					
			return
				bound1.CompareTo(bound2) <= 0
					? factory(bound1, bound2)
					: factory(bound2, bound1);
		}
	}
