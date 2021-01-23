	// Use a static instance of the cache to ensure all threads use it.
	private static _summariesCache;
    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
        if (_summariesCache == null)
        {
            _summariesCache = new SummariesCache(requestContext.HttpContext);
        }
        base.Initialize(requestContext);
    }
	private List<ProjectDataSummary> GetAllSummaries()
	{
		List<ProjectDataSummary> summaries = new List<ProjectDataSummary>();
		//use setting in web.config if we want to force no cache, but set to false in released version
		if (ConfigurationManager.AppSettings["NoCache"] == "true")
		{
			summaries = _service.GetAllSummaries();
		}
		else
		{
			summaries = _summariesCache.GetSummaries(_service, new CacheItemRemovedCallback(cacheCallback));
		}
		return summaries;
	}
	private void cacheCallback(String K, Object v, CacheItemRemovedReason r)
	{
		CacheItemRemovedReason reason = r;
		log.Info("Cache expired, reason: {0}", r.ToString());
	}
