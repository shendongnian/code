    using System.Data.Entity.ModelConfiguration;
    public static class ModelConfigurationHelper
    {
        public static EntityTypeConfiguration<T> ToSchema<T>(this EntityTypeConfiguration<T> config, string schema)
        {
            return config.ToTable(typeof(T).Name, schema);
        }
    }
    
