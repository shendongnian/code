    public void ProcessRequest(HttpContext context)
    {
        string productsKey = context.Request.QueryString("products");
        string cacheKey = "Products_" + productsKey;
        if (context.Cache[cacheKey] == null)
        {
            // lockObj declared on class level as 
            // private static readonly lockObj = new object();
            lock(lockObj)             {
                if (context.Cache[cacheKey] == null)
                {
                     using(StringWriter writer = new StringWriter())
                     {
                         var doc = getXml(productskey);
                         doc.Save(writer);
                         // Set caching options as required
                         context.Cache.Add(cacheKey, writer.GetStringBuilder().ToString(), null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));
                     }
                }
            }
            context.Response.Write(context.Cache[cacheKey]);
            return;
        }
