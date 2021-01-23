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
						_cache.Remove(valueFromCache);
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
					_cacheLock.EnterWriteLock();
					try
					{
						_cache.Add(new CacheObject() {User = result, UserId = userId, CreationDate = DateTime.Now});
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
