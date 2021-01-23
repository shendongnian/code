    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          foreach (var entity in modelBuilder.Model.GetEntityTypes())
          {
            modelBuilder.Entity(entity.Name).ToTable(entity.Name + "s");
          }
        }
