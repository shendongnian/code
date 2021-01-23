    protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            ...
            builder.Entity<Client>()
                .HasOptional(x => x.Card)
                .WithOptionalDependent(x => x.Client)
                .Map(x => x.MapKey("CardId"))
                .WillCascadeOnDelete(false);
            builder.Entity<Card>()
                .HasOptional(x => x.Client)
                .WithOptionalPrincipal(x => x.Card)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(builder);
        }
 
