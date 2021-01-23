    public class Dal
	{
		private sealed class Locker
		{
			private static readonly object DictionaryLocker = new object();
			private static readonly Dictionary<int, Locker>
				Locks = new Dictionary<int, Locker>();
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
				lock (DictionaryLocker)
				{
					if (!Locks.TryGetValue(id, out locker))
					{
						locker = new Locker();
						Locks.Add(id, locker);
					}
					++locker._num;
				}
				return locker._lockerObject;
			}
			public static void EndLock(int id)
			{
				lock (DictionaryLocker)
				{
					Locker locker = Locks[id];
					--locker._num;
					if (locker._num == 0)
						Locks.Remove(id);
				}
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
			    Locker.EndLock(id);
			}
			return item;
		}
	}
