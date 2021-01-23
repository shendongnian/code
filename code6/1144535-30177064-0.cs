    public class ApplicationOrderer : IBundleOrderer {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            if (!AppSettings.FeatureFlag_ServiceIntegrationsEnabled)
            {
                //Skip these files if the Service Integrations Feature is not enabled!
                //When this flag is removed, these lines can be deleted and the files will be included like normal
                var serviceIntegrationPathsToIgnore = new[]
                {
                    "/App/ServiceIntegrations/IntegrationSettingsModel.js",
                    "/App/ServiceIntegrations/IntegrationSettingsService.js",
                    "/App/ServiceIntegrations/ServiceIntegrationsCtrl.js"
                };
                files = files.Where(x => !serviceIntegrationPathsToIgnore.Contains(x.VirtualFile.VirtualPath));
            }
            return files;
        }
    }
    
