	public sealed class SummariesCache
	{
		private ReaderWriterLockSlim synclock = 
			new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
		public List<ProjectSummaryData> GetSummaries(
			ISummariesService service, 
			ref CacheItemRemovedCallback onRemoveCallback)
		{
			List<ProjectDataSummary> summaries;
			string key = "SummariesCache";
			bool success;
			synclock.EnterReadLock();
			try
			{
				success = TryGetCacheValue(key, out summaries);
			}
			finally
			{
				synclock.ExitReadLock();
			}
			
			if (!success)
			{
				synclock.EnterWriteLock();
				try
				{
					if (!TryGetCacheValue(key, out summaries))
					{
						//cache empty, retrieve values
						summaries = service.GetAllSummaries();
						
						// load the cache (using Insert)
						HttpContext.Current.Cache.Insert(
							key, 
							summaries, 
							null, 
							new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59), 
							Cache.NoSlidingExpiration, 
							CacheItemPriority.NotRemovable, 
							onRemoveCallback
						);
					}
				}
				finally
				{
					synclock.ExitWriteLock();
				}
			}
			
			return summaries;
		}
		private bool TryGetValue(string key, out List<ProjectSummaryData> value)
		{
			value = HttpContext.Current.Cache["key"] as List<ProjectDataSummary>;
			if (value != null)
			{
				return true;
			}
			return false;
		}
	}
