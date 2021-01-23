        public overridee OnModelCreating(DbModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Book>()
            .HasRequired(b => b.CreatedByUser)
            .WithMany(u => u.Books)
            .HasForeignKey(b => b.CreatedBy);
        }
