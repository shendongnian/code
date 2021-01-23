    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Order>().HasMany(x => x.Lines).WithRequired(x => x.Order).WillCascadeOnDelete();
        }
