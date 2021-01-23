    public static void RegisterBundles(BundleCollection bundles)
    {
        ...
        //Discomment to try bundling in debug
        //BundleTable.EnableOptimizations = true;
        
        var transform = new DisableCacheOverHttpsTransform();
        foreach (var bundle in bundles)
        {
            bundle.Transforms.Add(transform);
        }
    }
