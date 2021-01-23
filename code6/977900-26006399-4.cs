        /// <summary>
        /// Views the CMS page
        /// </summary>
        /// <param name="uri">The current Request.Url</param>
        /// <param name="user">The current User</param>
        /// <returns>The filename of the requested page</returns>
        public string View(Uri uri, User user)
        {
            var path = uri.AbsolutePath; // Get our Requested Url
            var queryString = uri.Query;
            var pages = this.GetPublished();
            var page = pages.Where(model => model.Path.Equals(path, StringComparison.OrdinalIgnoreCase)).SingleOrDefault(); // Try to get the page
            if (page == null) // If our page is null
                page = pages.Where(model => model.Path.Equals(VirtualPathUtility.RemoveTrailingSlash(VirtualPathUtility.GetDirectory(path)))).SingleOrDefault(); // try to get the page based off the directory
            if (page == null) // If the page is still null, then it doesn't exist
                throw new HttpException(404, "This page has been deleted or removed."); // Throw the 404 error
            if (page.Restricted && user == null) // If our page is restricted and we are not logged in
                return "~/Account/LogOn?ReturnUrl=" + page.Path + queryString; // Redirect to the login page
            if (user != null && page.Restricted)
            {
                if (PageService.IsForbidden(page, user))
                    throw new HttpException(401, "You do not have permission to view this page."); // Throw 401 error
            }
            return Path.GetFileNameWithoutExtension(page.Id.ToString());
        }
