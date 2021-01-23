    public class ApplicationPoolService : IApplicationPoolService
    {
        public bool IsShuttingDown()
        {
            return System.Web.Hosting.HostingEnvironment.ShutdownReason != ApplicationShutdownReason.None;
        }
    }
    private void ReportRemovedCallback(string key, object value, CacheItemRemovedReason reason)
    {
        if (!ApplicationPoolService.IsShuttingDown())
        {
            var str = $"Removed cached item with key {key} and count {(value as IDictionary)?.Count}, reason {reason}";
            LoggingService.Log(LogLevel.Info, str);
        }
    }
    HttpRuntime.Cache.Insert(CacheDictKey, dict, dependencies: null,
                absoluteExpiration: DateTime.Now.AddMinutes(absoluteExpiration),
                slidingExpiration: slidingExpiration <= 0 ? Cache.NoSlidingExpiration : TimeSpan.FromMinutes(slidingExpiration),
                priority: CacheItemPriority.NotRemovable,
                onRemoveCallback: ReportRemovedCallback);
