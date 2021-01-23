        public IList<Page> Pages
        {
            get
            {
                using (var uow = new UnitOfWork<SkipstoneContext>())
                {
                    var companyService = new CompanyService(uow);
                    var company = companyService.GetTenant();
                    if (company != null)
                    {
                        var pageService = new PageService(uow, company.Id);
                        return pageService.GetPublished();
                    }
                }
                return null;
            }
        }
        public override bool FileExists(string virtualPath)
        {
            if (IsVirtualPath(virtualPath))
            {
                if (FindPage(virtualPath) != null)
                {
                    var file = (PageVirtualFile)GetFile(virtualPath);
                    return file.Exists;
                }
            }
            return Previous.FileExists(virtualPath);
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsVirtualPath(virtualPath))
            {
                var page = FindPage(virtualPath);
                if (page != null)
                {
                    var decodedString = Uri.UnescapeDataString(page.ViewData);
                    var bytes = Encoding.ASCII.GetBytes(decodedString);
                    return new PageVirtualFile(virtualPath, bytes);
                }
            }
            return Previous.GetFile(virtualPath);
        }
        public override System.Web.Caching.CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsVirtualPath(virtualPath))
                return null;
            return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
        public override string GetFileHash(string virtualPath, System.Collections.IEnumerable virtualPathDependencies)
        {
            if (IsVirtualPath(virtualPath))
                return Guid.NewGuid().ToString();
            return Previous.GetFileHash(virtualPath, virtualPathDependencies);
        }
        private Page FindPage(string virtualPath)
        {
            var virtualName = VirtualPathUtility.GetFileName(virtualPath);
            var virtualExtension = VirtualPathUtility.GetExtension(virtualPath);
            try
            {
                if (Pages != null)
                {
                    var id = Convert.ToInt32(virtualName.Replace(virtualExtension, ""));
                    var page = Pages.Where(model => model.Id == id && model.Extension.Equals(virtualExtension, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
                    return page;
                }
            }
            catch(Exception ex)
            {
                // Do nothing
            }
            return null;
        }
        private bool IsVirtualPath(string virtualPath)
        {
            var path = (VirtualPathUtility.GetDirectory(virtualPath) != "~/") ? VirtualPathUtility.RemoveTrailingSlash(VirtualPathUtility.GetDirectory(virtualPath)) : VirtualPathUtility.GetDirectory(virtualPath);
            if (path.Equals("~/Views/Routing", StringComparison.OrdinalIgnoreCase) || path.Equals("/Views/Routing", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }
