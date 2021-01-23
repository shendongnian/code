    using System;
    using System.Configuration;
    using Microsoft.Azure;
    
    namespace Namespace1 {
        public class RedisConnectionStringProvider {
    
            public static string GetConnectionString() {
    			const string redisConnectionString="redisConnectionString";
                var cloudConfigurationValue = CloudConfigurationManager.GetSetting(redisConnectionString);
                if (!String.IsNullOrEmpty(cloudConfigurationValue))
                    return cloudConfigurationValue;
    
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[redisConnectionString];
    
                if (connectionStringSettings == null) {
                    throw new ConfigurationErrorsException("A connection string is expected for " + redisConnectionString);
                }
    
                return connectionStringSettings.ConnectionString;
    
            }
