    class OwnerConfiguration: EntityTypeConfiguration<Owner>
        {
            public OwnerConfiguration()
            {
                HasKey(x => x.OwnerId);
            }
        }
