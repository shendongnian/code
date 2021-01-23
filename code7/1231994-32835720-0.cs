    public void Logto<T>(T modifyObject, IEnumerable<dynamic> query, decimal Id) where T : class, IEntity
    {
         var original = db.Set<T>().AsNoTracking().FirstOrDefault(e => e.N100 == Id);
         var modified = original.ModifiedValues<T>(modifyObject).ToList();
         // some code here
    }
