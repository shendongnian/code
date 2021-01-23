    public class ProviderConfig: EntityTypeConfiguration<Provider>
        {
            public ProviderConfig()
            {
        this.Property(p => p.ProviderID)
                    .HasColumnName("provider_id")
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
    }
    }
