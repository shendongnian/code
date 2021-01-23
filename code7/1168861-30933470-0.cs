        public class DependenciesFromAppSettings : AbstractFacility
    {
        protected override void Init()
        {
            var dic = ConfigurationManager
                 .AppSettings
                 .AllKeys
                 .ToDictionary(k => k, k => ConfigurationManager.AppSettings[k]);
            Kernel.Resolver.AddSubResolver(new DependenciesFromAppSettingsResolver(dic));
        }
    }
