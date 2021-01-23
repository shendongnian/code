        /// <summary>
        /// Creates database structure not supported with Annotations using Fluent syntax.
        /// </summary>
        /// <param name="optionsBuilder">The configuration interface.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasIndex(
                story => new { story.Date, story.Published }).IsUnique(false);
        }
