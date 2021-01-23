    public class MyContext : DbContext
    {
        ..........
        public int SaveChanges(string username)
        {
            //Set TrackedEntity update columns
            foreach (var entry in ChangeTracker.Entries<TrackedEntity>())
            {
                if (entry.State != EntityState.Unchanged && !entry.Entity.GetType().Name.Contains("_History")) //ignore unchanged entities and history tables
                {
                    entry.Entity.Modified = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = username;
                    entry.Entity.Version += 1;
                    //add original values to history table (skip if this entity is not yet created)                 
                    if (entry.State != EntityState.Added && entry.Entity.GetType().BaseType != null)
                    {
                        //check the base type exists (actually the derived type e.g. Record)
                        Type entityBaseType = entry.Entity.GetType().BaseType;
                        if (entityBaseType == null)
                            continue;
                        //check there is a history type for this entity type
                        Type entityHistoryType = Type.GetType("MyEntityNamespace.Entities." + entityBaseType.Name + "_History");
                        if (entityHistoryType == null)
                            continue;
                        //create history object from the original values
                        var history = Activator.CreateInstance(entityHistoryType);
                        foreach (PropertyInfo property in entityHistoryType.GetProperties().Where(p => p.CanWrite && entry.OriginalValues.PropertyNames.Contains(p.Name)))
                            property.SetValue(history, entry.OriginalValues[property.Name], null);
                        //add the history object to the appropriate DbSet
                        MethodInfo method = typeof(MyContext).GetMethod("AddToDbSet");
                        MethodInfo generic = method.MakeGenericMethod(entityHistoryType);
                        generic.Invoke(this, new [] { history });
                    }
                }
            }
            return base.SaveChanges();
        }
        public void AddToDbSet<T>(T value) where T : class
        {
            PropertyInfo property = GetType().GetProperties().FirstOrDefault(p => p.PropertyType.IsGenericType
                && p.PropertyType.Name.StartsWith("DbSet")
                && p.PropertyType.GetGenericArguments().Length > 0
                && p.PropertyType.GetGenericArguments()[0] == typeof(T));
            if (property == null)
                return;
            ((DbSet<T>)property.GetValue(this, null)).Add(value);
        }
        ..........
    }
