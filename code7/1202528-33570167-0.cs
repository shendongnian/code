    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                           "~/Scripts/jquery-{version}.js",
                           "~/Scripts/globalize.js",
                           "~/Scripts/globalize.culture.uk-UA.js"));
    
    bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                          "~/Scripts/bootstrap.js",
                          "~/Scripts/bootstrap-datepicker.js",
                          "~/Scripts/bootstrap-datepicker.uk.js",
                          "~/Scripts/respond.js"));
     
    bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/bootstrap.css",
                          "~/Content/datepicker.css",
                          ));
