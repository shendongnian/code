    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    { 
     ...
        modelBuilder.Entity<Item> =>
        {
            entity
                .HasMany(e => e.RelatedItems )
                .WithOne(e => e.ParentItem) 
                .HasForeignKey(e => e.ParentItemId );
        });
      ...
    
    }
