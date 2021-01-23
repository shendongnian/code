    public static void RegisterBundles(BundleCollection bundles)
     {
       BundleTable.EnableOptimizations = true;
       bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
       bundles.Add(new ScriptBundle("~/bundles/globalisation").Include(
                "~/Scripts/globalize.js",                
                "~/Scripts/globalize/currency.js",
                "~/Scripts/globalize/date.js",
                "~/Scripts/globalize/message.js",
                "~/Scripts/globalize/number.js",
                "~/Scripts/globalize/plural.js",
                "~/Scripts/globalize/relative-time.js"));
       bundles.Add(new ScriptBundle("~/bundles/globalisationEN").Include(
               "~/Scripts/GlobalisationCulture/globalize.culture.en-AU.js"));
       bundles.Add(new ScriptBundle("~/bundles/globalisationES").Include(
               "~/Scripts/GlobalisationCulture/globalize.culture.es-AR.js"));
       bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.10.3.js"));      
       bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.globalize.js"));
      }
