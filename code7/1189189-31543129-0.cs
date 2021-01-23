    string bundlePath = "~/bundles/jquery";
    var bundleContext = new BundleContext(new HttpContextWrapper(HttpContext.Current), BundleTable.Bundles, bundlePath);
    Bundle bundle = BundleTable.Bundles.GetBundleFor(bundlePath);
    var bundleResponse = bundle.GenerateBundleResponse(bundleContext);
    var bundleReflection = bundleResponse.GetType();
    var method = bundleReflection.GetMethod("GetContentHashCode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
     
    var contentHash = method.Invoke(bundleResponse, null);
