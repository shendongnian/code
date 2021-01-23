    public IQueryable<CustomObject> PerformQuery(int id) 
    {
     ctx.Configuration.LazyLoadingEnabled = false;
     ctx.Configuration.AutoDetectChangesEnabled = false;
     IQueryable<CustomObject> customObjectQueryable = ctx.CustomObjects.Where(x => x.Id == id);
     var selectQuery = customObjectQueryable.Select(x => x.YourObject)
                                                      .Include(c => c.YourFirstCollection)
                                                      .Include(c => c.YourFirstCollection.OtherCollection)
                                                      .Include(c => c.YourSecondCollection);
     var otherObjects = customObjectQueryable.SelectMany(x => x.OtherObjects);
           
     selectQuery.FirstOrDefault();
     otherObjects.ToList();
     return customObjectQueryable;
     }
