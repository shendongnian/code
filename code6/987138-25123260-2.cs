    public class DisableCacheOverHttpsTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            if (context.HttpContext.Request.IsSecureConnection)
            {
                //disable cache on https
                response.Cacheability = HttpCacheability.NoCache;
            }
        }
    }
