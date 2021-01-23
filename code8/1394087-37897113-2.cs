    /// DbConfiguration belongs to System.Data
    public class EntityFrameworkConfig : DbConfiguration
    {
        public EntityFrameworkConfig()
        {
            //We set configurations for entity framework here so that we don't have to add it in the app.config
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
    /// <summary>
    /// This class with the DbConfigurationType attribute allows EntityFramework to know    
    /// to get its config from the EntityFrameworkConfig class instead of the app.config
    /// </summary>
    [DbConfigurationType(typeof(EntityFrameworkConfig))]
    public partial class MyEntities
    {
        /// <summary>
        /// This constructor allows us to pass connection strings at runtime
        /// </summary>
        /// <param name="connectionString">Entity Framework connection string</param>
        public MyEntities(string connectionString) : base(connectionString)
        {
        }
    }
