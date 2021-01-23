	public class CachedUserRepository : IUserRepository
	{
		private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
		private IUserRepository _userRepository;
		private List<CacheObject> _cache = new List<CacheObject>();
		private int _cacheDuration = 60;
		public CachedUserRepository(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public User GetUser(int userId)
		{
			bool addToCache = false;
			// Enter an upgradeable read lock because we might have to use a write lock if having to update the cache
			// Multiple threads can read the cache at the same time
			_cacheLock.EnterUpgradeableReadLock();
			try
			{
				CacheObject valueFromCache = _cache.SingleOrDefault(u => u.UserId == userId);
				// user was found
				if (valueFromCache != null)
				{
					// if cache is outdated then remove value from it
					if (valueFromCache.CreationDate.AddSeconds(_cacheDuration) < DateTime.Now)
					{
						// Upgrade to a write lock, as an item has to be removed from the cache.
						// We will only enter the write lock if nobody holds either a read or write lock
						_cacheLock.EnterWriteLock();
						try
						{
							_cache.Remove(valueFromCache);
						}
						finally
						{
							_cacheLock.ExitWriteLock();
						}
						addToCache = true;
					}
					else
					{
						// update  cache date
						valueFromCache.CreationDate = DateTime.Now;
						return valueFromCache.User;
					}
				}
				// user is absent in cache
				else
				{
					addToCache = true;
				}
				if (addToCache)
				{
					User result = _userRepository.GetUser(userId);
					// Upgrade to a write lock, as an item will (probably) be added to the cache.
					// We will only enter the write lock if nobody holds either a read or write lock
					_cacheLock.EnterWriteLock();
					try
					{
						if (_cache.Any(u => u.UserId != userId))
						{
							_cache.Add(new CacheObject() {User = result, UserId = userId, CreationDate = DateTime.Now});
						}
					}
					finally
					{
						_cacheLock.ExitWriteLock();
					}
					return result;
				}
			}
			finally
			{
				_cacheLock.ExitUpgradeableReadLock();
			}
			return null;
		}
	}
