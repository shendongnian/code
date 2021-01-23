     public override int SaveChanges()
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    foreach (var pi in entry.Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                    {
                        entry.Property(pi.Name).CurrentValue = pi.GetValue(entry.Entity);
                    }
                }
                return base.SaveChanges();
            }
