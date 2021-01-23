    public virtual void Update(T updatedObject, int key, params string[] navigationProperties) {
        if (updatedObject == null) {
            return;
        }
        using (var databaseContext = new U()) {
            databaseContext.Database.Log = Console.Write;
            T foundEntity = databaseContext.Set<T>().Find(key);
            var entry = databaseContext.Entry(foundEntity);
            entry.CurrentValues.SetValues(updatedObject);                
            foreach (var prop in navigationProperties) {
                var collection  = entry.Collection(prop);
                collection.Load();
                collection.CurrentValue = typeof(T).GetProperty(prop).GetValue(updatedObject);
            }
            databaseContext.SaveChanges();
        }
    }
