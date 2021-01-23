    namespace myApp.Data.Models
    {
        [DbConfigurationType(typeof(myDBContextConfig))]
        partial class myDBEntities
        {
    
            public myDBEntities(string connectionString) : base(connectionString)
            {
            }
        }
    
          public  class myDBContextConfig : DbConfiguration
            {
                public myDBContextConfig()
                {
                    SetProviderServices("System.Data.EntityClient", 
                    SqlProviderServices.Instance);
                    SetDefaultConnectionFactory(new SqlConnectionFactory());
                }
            }
        }
