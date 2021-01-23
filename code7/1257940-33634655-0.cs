    namespace ConfigurationExperiment
    {
        using System.Collections.Generic;
        using System.Xml.Linq;
        using System.Xml.XPath;
        public interface IConfiguration
        {
            IEnumerable<IItemConfiguration> ItemConfigurations { get; }
        }
        public interface IItemConfiguration
        {
            IDbConfiguration DbConfiguration { get; }
            INotificationConfiguration NotificationConfiguration { get; }
        }
        public interface IDbConfiguration
        {
            string ConnectionString { get; }
        }
        public interface INotificationConfiguration
        {
            IEmailConfiguration EmailConfiguration { get; }
            IPhoneConfiguration PhoneConfiguration { get; }
            ISmsConfiguration SmsConfiguration { get; }
        }
        public interface IEmailConfiguration
        {
            //primitive stuff here
        }
        public interface IPhoneConfiguration
        {
            //primitive stuff here
        }
        public interface ISmsConfiguration
        {
            //primitive stuff here
        }
        public interface IConfigurationRepository
        {
            IConfiguration GetConfiguration();
        }
        internal class ConfigurationRepository : IConfigurationRepository
        {
            private readonly XElement _configurationElement;
            public ConfigurationRepository(XElement configurationElement)
            {
                _configurationElement = configurationElement;
            }
            public IConfiguration GetConfiguration()
            {
                var result = new Configuration();
                foreach (var itemElement in _configurationElement.XPathSelectElements("//item"))
                {
                    var item = new ItemConfiguration();
                    //item.DbConfiguration = ...;
                    //item.NotificationConfiguration = ...;
                    result.Add(item);
                }
                return result;
            }
            private class Configuration : IConfiguration
            {
                private readonly List<ItemConfiguration> _itemConfigurations;
                public Configuration()
                {
                    _itemConfigurations = new List<ItemConfiguration>();
                }
                public IEnumerable<IItemConfiguration> ItemConfigurations
                {
                    get { return _itemConfigurations; }
                }
                public void Add(ItemConfiguration item)
                {
                    _itemConfigurations.Add(item);
                }
            }
            private class ItemConfiguration : IItemConfiguration
            {
                public IDbConfiguration DbConfiguration { get; set; }
                public INotificationConfiguration NotificationConfiguration { get; set; }
            }
        }
    }
