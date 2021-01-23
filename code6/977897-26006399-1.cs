        protected override IAsyncResult BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, object state)
        {
            var vpp = new SkipstoneVirtualPathProvider(); // Create an instance of our VirtualPathProvider class
            var requestContext = ((MvcHandler)httpContext.Handler).RequestContext; // Get our request context
            var path = requestContext.HttpContext.Request.Url.AbsolutePath; // Get our requested path
            var pages = vpp.Pages; // Get all the published pages for this company
            if (pages != null && !string.IsNullOrEmpty(path)) // If we have any pages and we have a path
            {
                var page = this.MatchPage(pages, path);
                if (page != null) // If we find the page
                {
                    requestContext.RouteData.Values["controller"] = "Routing"; // Set the controller
                    requestContext.RouteData.Values["action"] = "Index"; // And the action
                }
            }
            return base.BeginProcessRequest(httpContext, callback, state);
        }
        private Page MatchPage(IList<Page> pages, string path)
        {
            if (path == "/" || !path.EndsWith("/"))
            {
                var page = pages.Where(model => model.Path.Equals(path, StringComparison.OrdinalIgnoreCase)).SingleOrDefault(); // Try to match the path first
                if (page == null) // If we have no page, then get the directory and see if that matches any page
                {
                    path = VirtualPathUtility.RemoveTrailingSlash(VirtualPathUtility.GetDirectory(path));
                    page = pages.Where(model => model.Path.Equals(path, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
                }
                return page; // return our page or null if no page exists
            }
            return null; // return null if anything fails
        }
