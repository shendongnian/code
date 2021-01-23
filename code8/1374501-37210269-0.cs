    public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries<Entity>().Where(E => E.State == EntityState.Added).ToList();
            AddedEntities.ForEach(E => 
            {
                /// Do whatever you like !
            });
            return base.SaveChanges();
        }
