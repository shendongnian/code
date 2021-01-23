    public MyContext() : base("MyConnection")
    {
      var objectContext = ((IObjectContextAdapter) this).ObjectContext;
      objectContext.SavingChanges += (sender, args) =>
      {
        foreach (var entry in ChangeTracker.Entries())
        {
          var entity = entry.Entity;
          var state = entry.State;
          if (entity is BaseEntity)
          {
            ProcessEntity((BaseEntity)entity, state);
          }
        }
        ChangeTracker.DetectChanges();
      };
    }
    private void ProcessEntity<T>(T entity, EntityState state) where T : BaseEntity
    {
      switch (state)
      {
        case EntityState.Added:
          var set = Set<T>();
          (entity as BaseEntity).Id = GetMaxId(set) + 1;
          break;
      }
    }
