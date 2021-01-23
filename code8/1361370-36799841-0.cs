        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Gender>().HasKey(x => x.ID);
            modelBuilder.Entity<Gender>().Property(x => x.Description).HasMaxLength(255);
            modelBuilder.Entity<Gender>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Gender>().Property(x => x.createdID).IsRequired();
            modelBuilder.Entity<Gender>().Property(x => x.createdOn).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
