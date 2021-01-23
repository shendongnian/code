    public class test : Itest
    {
        protected readonly IOptions<AppSettings> _AppSettings;
        public test(IOptions<AppSettings> AppSettings)
        {
            _AppSettings = AppSettings;
        }
        public IOptions<AppSettings> AppSettings
        {
            get
            {
                return _AppSettings;
            }
        }
        public string GetAppVersion()
        {
            return _AppSettings.Value.AppVersion;
        }
    }
