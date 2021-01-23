    public void OriginalValues(object entity)
    {
        ChangeTracker.DetectChanges();
        var changed = ChangeTracker.Entries()
                .Where(x=>x.State != EntityState.Unchanged).ToList();
        foreach (var entry in changed)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    Debug.WriteLine("object of type " + entry.Entity.GetType().Name 
                       + "created:");
                    foreach(var name in entry.CurrentValues.PropertyNames)
                    {
                        Debug.WriteLine(name + " : " + entry.CurrentValues[name]);
                    }
                break;
                case EntityState.Deleted:
                    Debug.WriteLine("object of type " + entry.Entity.GetType().Name 
                       + "deleted:");
                    LogObjectValues(entry.Entity);
                break;
                case EntityState.Modified:
                    Debug.WriteLine("object of type " + entry.Entity.GetType().Name 
                       + "updated:");
                    Debug.WriteLine("current values:");
                    foreach(var name in entry.CurrentValues.PropertyNames)
                    {
                        Debug.WriteLine(name + " : " + entry.CurrentValues[name]);
                    }
                    Debug.WriteLine("original values:");
                    foreach(var name in entry.OriginalValues.PropertyNames)
                    {
                        Debug.WriteLine(name + " : " + entry.CurrentValues[name]);
                    }
                break;
             }
         }
     }
     private void LogObjectValues(object obj)
     {
        if (obj == null)
            return;
        var props = obj.GetType().GetProperties();
        Debug.WriteLine("original values:");
        foreach (var prop in props)
        {
            Debug.WriteLine(prop.Name + " : " + prop.GetValue(obj));
        }
     }
