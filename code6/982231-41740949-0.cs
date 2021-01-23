        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //--> EntityTypeConfiguration<Your Model Configuration>
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<CategoryMapping>());  
            base.OnModelCreating(modelBuilder);
        }
