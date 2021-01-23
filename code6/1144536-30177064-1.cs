    public static void RegisterBundles(BundleCollection bundles)
    {
            var appBundle = new ScriptBundle("~/bundles/app")
                .IncludeDirectory("~/App/", "*.js", true)
            appBundle.Orderer = new ApplicationOrderer();
            bundles.Add(appBundle);
    }
