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
                    foreach(var name in entry.OriginalValues.PropertyNames)
                    {
                        Debug.WriteLine(name + " : " + entry.OriginalValues[name]);
                    }
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
                        Debug.WriteLine(name + " : " + entry.OriginalValues[name]);
                    }
                break;
             }
         }
     }
