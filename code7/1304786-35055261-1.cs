    public static void RegisterBundles(BundleCollection bundles)
    {
            // The jQuery bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            //"~/Scripts/jquery-1.9.1.*",
                            "~/Scripts/jquery.min.js"
                            //"~/Scripts/jquery-ui-1.10.2.custom.js"
                            ));
    
    bundles.IgnoreList.Clear();
    bundles.IgnoreList.Ignore("*.intellisense.js");
    bundles.IgnoreList.Ignore("*-vsdoc.js");
    bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
    }
