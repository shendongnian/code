    using System.Data.Entity.ModelConfiguration.Conventions;
    public static class ConventionTypeConfigurationHelper
    {
        public static ConventionTypeConfiguration ToSchema(this ConventionTypeConfiguration config, string toSchema)
        {
           config.ToTable(tableName: config.ClrType.Name, schemaName: toSchema);
           return config;
        }
    }  
    
