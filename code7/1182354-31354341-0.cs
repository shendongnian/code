    public override int SaveChanges()
            {
                SyncObjectsStatePreCommit();
                var changes = base.SaveChanges();
                SyncObjectsStatePostCommit();
                return changes;
            }
