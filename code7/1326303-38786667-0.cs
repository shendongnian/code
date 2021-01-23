    using Configuration.Interfaces;
    using Persistence.Interfaces;
    using Worker.Services.Interfaces;
    
    namespace Worker.Services
    {
        public class MyWorkerService : IMyWorkerService
        {
            private readonly IConnectionStrings _connectionStrings;
            private readonly IAzureServiceConfiguration _azureServiceConfiguration;
            private readonly IMicrosoftStorageConfig _microsoftStorageConfig;
            private readonly IPersitenceServiceConfigDependent _persitenceServiceConfigDependent;
            private readonly IAppConfigSettings _appConfigSettings;
        public MyWorkerService(
            IPersitenceServiceConfigDependent persitenceServiceConfigDependent,
            IConnectionStrings connectionStrings,
            IAzureServiceConfiguration azureServiceConfiguration,
            IMicrosoftStorageConfig microsoftStorageConfig,
            IAppConfigSettings appConfigSettings)
        {
            _connectionStrings = connectionStrings;
            _azureServiceConfiguration = azureServiceConfiguration;
            _microsoftStorageConfig = microsoftStorageConfig;
            _persitenceServiceConfigDependent = persitenceServiceConfigDependent;
            _appConfigSettings = appConfigSettings;
        }
        public string DoWork()
        {
            _persitenceServiceConfigDependent.ConfigDependentAction("blah");
            var configSetting = _microsoftStorageConfig.StorageConnectionString;
            return $"Job done :" +
                   $" <br> msConfig : {configSetting}, " +
                   $" <br> azureConfig.ServiceBusConnectionString:{_azureServiceConfiguration.ServiceBusConnectionString} " +
                   $" <br> webConfig.SubscriptionId:{_appConfigSettings.SubscriptionId} " +
                   $" <br> connectionStrings.DefaultConnection :{_connectionStrings.DefaultConnection}";
        }
    }
    }
