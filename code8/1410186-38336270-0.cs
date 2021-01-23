      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<NewsToSave>()
                .HasMany(c => c.Categories).WithMany(i => i.NewsToSaves)
                .Map(t => t.MapLeftKey("NewsToSaveID")
                    .MapRightKey("CategoryID")
                    .ToTable("NewsCategory"));
        }
