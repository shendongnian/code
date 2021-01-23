        public override int SaveChanges()
        {
            //set default value for your property
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("YOUR_PROPERTY") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("YOUR_PROPERTY").CurrentValue == null)
                        entry.Property("YOUR_PROPERTY").CurrentValue = YOUR_DEFAULT_VALUE;
                }
            }
            return base.SaveChanges();
        }
