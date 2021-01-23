    dbContext.Configuration.AutoDetectChangesEnabled = false;
    var folder = dbContext.Folders.First();
    var image = new Image();
    image.Folder = folder;
    image.<SomeFields> = "<SomeData>";
    **dbContext.Entry(image).State = EntityState.Added; **
    dbContext.SaveChanges();
