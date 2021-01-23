        private string _GetEmbeddedPath(string path)
        {
            if (path.StartsWith("~/")) path = path.Substring(1);
            if (HostingEnvironment.ApplicationVirtualPath != null)
            {
                if (path.StartsWith(HostingEnvironment.ApplicationVirtualPath)) path = path.Substring(HostingEnvironment.ApplicationVirtualPath.Length);
            }
            path = path.ToLowerInvariant();
            path = "Merz.Ems.Core" + path.Replace('/', '.');
            return GetType().Assembly.GetManifestResourceNames().FirstOrDefault(o => o.Equals(path, StringComparison.OrdinalIgnoreCase));
        }
