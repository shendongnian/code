        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Client>())
            {
                if (entry.State == EntityState.Modified)
                {
                    // Get the changed values.
                    var modifiedProps = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).GetModifiedProperties();
                    var currentValues = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).CurrentValues;
                    foreach (var propName in modifiedProps)
                    {
                        var newValue = currentValues[propName];
                        //log changes
                    }
                }
            }
            return base.SaveChanges();
        }
