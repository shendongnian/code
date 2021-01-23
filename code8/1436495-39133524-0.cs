    public static class DbContextExtensions
    {
        public static void AddOrAttach<T>(this DbContext context, T entity)
            where T : class
        {
    #region leave conditions
            if (entity == null) return;
            
            var entry = context.Entry(entity);
            var leaveStates = new[]
            {
                EntityState.Deleted,
                EntityState.Modified,
                EntityState.Unchanged
            };
            if (leaveStates.Contains(entry.State)) return;
    #endregion
            
            var entityKey = context.GetEntityKey(entity);
            if (entityKey == null)
            {
                entry.State = EntityState.Unchanged;
                entityKey = context.GetEntityKey(entity);
            }
            if (entityKey.EntityKeyValues == null 
                || entityKey.EntityKeyValues.Select(ekv => (int)ekv.Value).All(v => v <= 0))
            {
                entry.State = EntityState.Added;
            }
        }
        
        public static EntityKey GetEntityKey<T>(this DbContext context, T entity)
            where T : class
        {
            var oc = ((IObjectContextAdapter)context).ObjectContext;
            ObjectStateEntry ose;
            if (null != entity && oc.ObjectStateManager
                                    .TryGetObjectStateEntry(entity, out ose))
            {
                return ose.EntityKey;
            }
            return null;
        }
    }
