        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ITrackableClient>())
            {
                if (entry.State == EntityState.Modified)
                {
                    // Same code as example above.
                }
            }
            return base.SaveChanges();
        }
