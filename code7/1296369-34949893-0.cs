    public override CacheDependency GetCacheDependency(
        string virtualPath, 
        IEnumerable virtualPathDependencies, 
        DateTime utcStart)
    {
        // Use correct code here :)
        if(virtualPath.StartsWith("~/SomeFolder")
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
