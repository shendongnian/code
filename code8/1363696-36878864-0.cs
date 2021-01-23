          using (DbContextTransaction txUpdate = dbUpdate.Database.BeginTransaction())
            {
                dbUpdate.Configuration.AutoDetectChangesEnabled = false;
                foreach(var Item in UpdateItems)
                {
                    dbUpdate.Entry<V2Contact>(Item).State = EntityState.Modified;
                }
                dbUpdate.Configuration.AutoDetectChangesEnabled = true;
                dbUpdate.ChangeTracker.DetectChanges();
                dbUpdate.SaveChanges();
                txUpdate.Commit();
            }
