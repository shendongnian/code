        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Noticia>(t => t.IsValid);
            modelBuilder.Ignore<Noticia>(t => t.ValidationResult);
            base.OnModelCreating(modelBuilder);
        }
