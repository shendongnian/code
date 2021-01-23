        public bool IsContextDirty(DataServiceContext ctx)
        {
    #if DEBUG
            var changed = ctx.ChangeTracker.Entries().Where(t => t.State != EntityState.Unchanged).ToList();
            changed.ForEach(
                (t) => Debug.WriteLine("entity Type:{0}", t.Entity.GetType()));
    #endif
            return ctx != null && ctx.ChangeTracker.HasChanges();
        }
        
