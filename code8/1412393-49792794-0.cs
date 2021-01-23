    using Microsoft.Extensions.Options;
        
    
    public class KeyUrls: IKeyUrls
    {
        public string BaseUrl = "";
        private readonly IOptions<ConfigurationManager> _configurationService;
        public KeyUrls(IOptions<ConfigurationManager> configurationservice)
        {
            _configurationService = configurationservice;
            BaseUrl = _configurationService.Value.BaseUrl;
        }
        public  string GetAllKeyTypes()
        {
            return $"{BaseUrl}/something";
        }
        public  string GetFilteredKeys()
        {
            return $"{BaseUrl}/something2";
        }
    }
