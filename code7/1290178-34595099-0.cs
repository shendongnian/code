        public void AttachListEntries<T>(List<T> entries) where T : class
        {
            for (var i = 0; i < entries.Count; i++)
            {
                var result = AttachToAndGetIfExists(entries[i]);
                if (result != null)
                {
                    entries[i] = result;
                }
            }
        }
        public T AttachToAndGetIfExists<T>(T entity) where T : class
        {
            var objContext = ((IObjectContextAdapter)Context).ObjectContext;
            ObjectSet<T> objectSet = objContext.CreateObjectSet<T>();
            var key = objContext.CreateEntityKey(string.Format("{0}.{1}", objectSet.EntitySet.EntityContainer.Name, objectSet.EntitySet.Name), entity);
            ObjectStateEntry entry;
            if (objContext.ObjectStateManager.TryGetObjectStateEntry(key, out entry))
            {
                if (entry.State == EntityState.Detached)
                {
                    objContext.AttachTo(key.EntitySetName, entry);
                }
                return (T)entry.Entity;
            }
            
            objContext.AttachTo(key.EntitySetName, entity);
            return null;
        }
