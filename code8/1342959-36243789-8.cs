	public static class StatefulRandomizer<T>
		// Use IEquatable<T> for Intersect()
		where T : IEquatable<T>
	{
		// this could be enhanced to be a percentage 
		// of elements instead of hardcoded
		private static Stack<T> _memory = new Stack<T>();
		private static IEnumerable<T> _cache;
		public static void UpdateWith(IEnumerable<T> newCache)
		{
			_cache = newCache.ToList();
			// Setup the stack again, keep only ones that match
			var matching = _memory.Intersect(newCache);
			_memory = new Stack<T>(matching);
		}
		public static T GetNextNonRepeatingRandom()
		{
			var nonrepeaters = _cache
				.Except(_memory);
			// Not familar with unity.. but this should make 
			// sense what I am doing
			var next = nonrepeaters.ElementAt(UnityEngine.Random(0, nonrepeaters.Count()-1));
			// this fast, Stack will know it's count so no GetEnumerator()
			// and _cache List is the same (Count() will call List.Count)
			if (_memory.Count > _cache.Count() / 2)
			{
				_memory.Pop();
			}
			_memory.Push(next);
			return next;
		}
	}
