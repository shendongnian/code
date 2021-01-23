    public class SiteSettings 
    {
        private static SiteSettings _instance;
        private Func<ITenantSettings> _tenantSettingsFactory;
        private SiteSettings(Func<ITenantSettings> tenantSettingsFactory)
        {
            _tenantSettingsFactory = tenantSettingsFactory;
        }
        public static void Initialise(Func<ITenantSettings> tenantSettingsFactory) 
        {
            _instance = new SiteSettings(tenantSettingsFactory);
        }
        public ITenantSettings TenantSettings { get { return _tenantSettingsFactory(); } }
        public static SiteSettings Instance
        {
            get {
                if (_instance == null) throw new InvalidOperationException();
                return _instance;
            }
        }
        public string DefaultTimeZone() 
        {
            return TenantSettings.DefaultTimeZone();
        }
    }
