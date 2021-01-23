    public static void RegisterBundles(BundleCollection bundles)
    {
    bundles.IgnoreList.Clear();
    bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
    
    BundleTable.EnableOptimizations = true;
    }
