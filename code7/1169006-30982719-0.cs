    public static class DynamicBundles
    {
        public static IHtmlString RenderSkin(string skinDirectory)
        {            
            BundleTable.Bundles.Add(new StyleBundle("~/Content/css/" + skinDirectory).Include(
            "~/Content/" + skinDirectory + "/reset.css", 
            "~/Content/" + skinDirectory + "/site.css", 
            "~/Content/" + skinDirectory + "/grids.css"));
        return Styles.Render("~/Content/css/" + skinDirectory);
        }
    }
