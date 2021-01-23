    public override CacheDependency GetCacheDependency(
        string virtualPath, 
        IEnumerable virtualPathDependencies, 
        DateTime utcStart)
    {
        // if(virtualPath.StartsWith("~/Embedded"))
        if(BundleTables.Bundles.Any(b => b.Path == virtualPath))
        {
            return null; 
        }
        if (this.IsEmbeddedPath(virtualPath))
        {
            return null;
        }
        else
        {
            return this._previous
                       .GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }
