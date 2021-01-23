        public static void RegisterBundles(BundleCollection bundles)
    {
            bundles.UseCdn = true;   //enable CDN     
        // How To add link to jquery on the CDN
        var jquryCdnPath = "http://mycdnsite/Content/js/jquery.unobtrusive-ajax.min.js";
    
        bundles.Add(new ScriptBundle("~/bundles/jquery",
                    jquryCdnPath).Include(
                    "~/Scripts/jquery-{version}.js"));
    
        }
