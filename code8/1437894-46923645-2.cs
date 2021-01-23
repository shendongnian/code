    public class SNSFactory : ISNSFactory
    {
        private readonly SNSConfig _snsConfig;
        private readonly IEnumerable<IAmazonSimpleNotificationService> _snsServices;
    
        public SNSFactory(
            IOptions<SNSConfig> snsConfig,
            IEnumerable<IAmazonSimpleNotificationService> snsServices
            )
        {
            _snsConfig = snsConfig.Value;
            _snsServices = snsServices;
        }
    
        public IAmazonSimpleNotificationService ForDefault()
        {
            return GetSNS(_snsConfig.SNSDefaultRegion);
        }
    
        public IAmazonSimpleNotificationService ForSMS()
        {
            return GetSNS(_snsConfig.SNSSMSRegion);
        }
    
        private IAmazonSimpleNotificationService GetSNS(string region)
        {
            return GetSNS(RegionEndpoint.GetBySystemName(region));
        }
    
        private IAmazonSimpleNotificationService GetSNS(RegionEndpoint region)
        {
            IAmazonSimpleNotificationService service = _snsServices.FirstOrDefault(sns => sns.Config.RegionEndpoint == region);
    
            if (service == null)
            {
                throw new Exception($"No SNS service registered for region: {region}");
            }
    
            return service;
        }
    }
    
    public interface ISNSFactory
    {
        IAmazonSimpleNotificationService ForDefault();
    
        IAmazonSimpleNotificationService ForSMS();
    }
