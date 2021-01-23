    using System.ComponentModel.DataAnnotations.Schema;
    
    public class ShippingConfigurationConfiguration : EntityTypeConfiguration<ShippingConfigurationEntity>
    {
        public ShippingConfigurationConfiguration()
        {
            HasKey(t => t.Id);
        
            Property(a => a.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
