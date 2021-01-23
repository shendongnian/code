        public static string GetBundleContents(string virtualPath)
        {
            OptimizationSettings config = new OptimizationSettings()
            {
                ApplicationPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath,
                BundleTable = BundleTable.Bundles
            };
            BundleResponse response = Optimizer.BuildBundle(virtualPath, config);
            return response.Content;
        }
        public static void WriteBundlesToDisk(string path)
        {
            foreach (var bundle in BundleTable.Bundles)
            {
                var bundleContents = BundleConfig.GetBundleContents(bundle.Path);
                File.WriteAllText(string.Format("{0}/{1}.{2}", path, bundle.Path.Split('/').Last(), BundleConfig.GetFileExtensionByBundleType(bundle)), bundleContents);
            }
        }
        public static string GetFileExtensionByBundleType(Bundle bundle) 
        {
            if (bundle is ScriptBundle)
                return "js";
            else if (bundle is StyleBundle)
                return "css";
            return "folderBundle";
        }
