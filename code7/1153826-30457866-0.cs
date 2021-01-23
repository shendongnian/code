    List<OldCategory > oldCategoryList = new List<OldCategory>();
    List<NewCategory > newCategoryList = new List<NewCategory>();
    
    oldCategoryList = dbContext.OldCategory .ToList();
    foreach (var item in oldCategoryList )
    {
       newCategoryList .Add(item);
    }
    dbContext.SaveChanges();
