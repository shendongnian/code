        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                var result = base.Properties;
                result.Add(new ConfigurationProperty("useSsl", typeof(bool)));
                
                return base.Properties;
            }
        }
