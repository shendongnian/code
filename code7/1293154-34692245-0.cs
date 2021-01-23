    public class ClientEntityTypeConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientEntityTypeConfiguration()
        {
            HasKey(x => x.ClientId);
            Property(x => x.ClientId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasMany(x => x.Jobs).WithOptional(x => x.Client);
        }
    }
