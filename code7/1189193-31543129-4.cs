    //This is the url passed to bundle definition in BundleConfig.cs
    string bundlePath = "~/bundles/jquery";
    //Need the context to generate response
    var bundleContext = new BundleContext(new HttpContextWrapper(HttpContext.Current), BundleTable.Bundles, bundlePath);
    //Bundle class has the method we need to get a BundleResponse
    Bundle bundle = BundleTable.Bundles.GetBundleFor(bundlePath);
    var bundleResponse = bundle.GenerateBundleResponse(bundleContext);
    //BundleResponse has the method we need to call, but its marked as
    //internal and therefor is not available for public consumption.
    //To bypass this, reflect on it and manually invoke the method
    var bundleReflection = bundleResponse.GetType();
    var method = bundleReflection.GetMethod("GetContentHashCode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
     
    //contentHash is whats appended to your url (url?###-###...)
    var contentHash = method.Invoke(bundleResponse, null);
