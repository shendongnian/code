        public static IHtmlString RenderScripts()
        {
            List<string> bundlePaths = new List<string>();
            HttpContext currentHttpContext = HttpContext.Current;
            var httpContext = new HttpContextWrapper(currentHttpContext);
            BundleContext bundlecontext = new BundleContext(httpContext, BundleTable.Bundles, "~/bundles/");
            bundlecontext.EnableInstrumentation = false;
            
            var bundleList = bundlecontext.BundleCollection.ToList().Where(b => b.Path.StartsWith("~/bundles/" + HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower() + "_"));
            
            foreach (Bundle bundleItem in bundleList)
            {
                bundlePaths.Add(bundleItem.Path);
            }
            return Scripts.Render(bundlePaths.ToArray());
        }
