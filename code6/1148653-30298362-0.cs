    public class Dal
	{
		private sealed class Locker
		{
			private static readonly ConcurrentDictionary<int, Locker>
				Locks = new ConcurrentDictionary<int, Locker>();
			private readonly object _lockerObject;
			private int _num;
			private Locker()
			{
				_num = 0;
				_lockerObject = new object();
			}
			public static object StartLock(int id)
			{
				Locker locker;
				if (!Locks.TryGetValue(id, out locker)) // minimize risk of instantiation objects
					locker = Locks.GetOrAdd(id, new Locker());
				++locker._num;
				return locker._lockerObject;
			}
			public static void EndLock(int id)
			{
				Locker locker;
				if (!Locks.TryGetValue(id, out locker))
					throw new InvalidOperationException();
				--locker._num;
				if (locker._num == 0 && Locks.TryRemove(id, out locker))
					throw new InvalidOperationException();
			}
		}
		public Entity GetEntity(int id)
		{
			var cacheKey = string.Format(".cache.key.{0}", id);
			var item = Cache.Get(cacheKey) as Entity;
			if (item != null)
				return item;
			object lockObject = Locker.StartLock(id);
			lock (lockObject)
			{
				// all exceptions are handled in this block.
				item = LoadEntityFromDatabase(id);
				Cache.Add(cacheKey, item);
			}
			// * Here is the removing problem: 
			Locker.EndLock(id);
			return item;
		}
	}
