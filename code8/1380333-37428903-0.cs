    notification = HttpRuntime.Cache[cacheKey] as Notification;
    HttpRuntime.Cache.Insert(key, notificationResult , null,
                    DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration,
                    CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(CacheItemRemoved));
    
     
 
