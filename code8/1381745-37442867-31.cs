    public interface ICachedRouteDataProvider<TPrimaryKey>
    {
        IDictionary<string, TPrimaryKey> GetVirtualPathToIdMap(HttpContextBase httpContext);
    }
CategoryCachedRouteDataProvider
