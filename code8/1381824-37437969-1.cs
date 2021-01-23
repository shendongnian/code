    public void ClearSitecoreDatabaseCache(Database db)
    {
    	// clear html cache
    	Sitecore.Context.Site.Caches.HtmlCache.Clear();
    
    	db.Caches.ItemCache.Clear();
    	db.Caches.DataCache.Clear();
    
    	//Clear prefetch cache
    	foreach (var cache in Sitecore.Caching.CacheManager.GetAllCaches())
    	{
    		if (cache.Name.Contains(string.Format("Prefetch data({0})", db.Name)))
    		{
    			cache.Clear();
    		}
    	}
    }
