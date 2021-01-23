    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.UseCdn = true;   // enable CDN     
        // How to add link to jQuery on the CDN ?
        var jqueryCdnPath = "http://mycdnsite/Content/js/jquery.unobtrusive-ajax.min.js";
    
        bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath)
               .Include("~/Scripts/jquery-{version}.js"));
    }
