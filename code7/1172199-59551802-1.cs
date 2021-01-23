        public override int SaveChanges()
        {
            //set default value for RegistedDate property
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    if ((DateTime)entry.Property("RegistedDate").CurrentValue == DateTime.MinValue)
                        entry.Property("RegistedDate").CurrentValue = DateTime.Now;
                }
            }
            //set default value for IsActive property
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("IsActive") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    if(entry.Property("IsActive").CurrentValue == null)
                        entry.Property("IsActive").CurrentValue = false;
                }
            }
            return base.SaveChanges();
        }
