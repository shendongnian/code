    var listOfRecordsToBeUpdated = await dbContext.History
            .Where(r => ids.Contains(r.Id)).ToListAsync();
    
    //It will detect the changes each time when you update the entity
    // Make sure you re-enable this after your bulk operation
    DataContext.Configuration.AutoDetectChangesEnabled = false;
  
    //Iterate through the records and assign your value
    listOfRecordsToBeUpdated.Foreach(x=>x.SyncOk = syncOk);
    DataContext.Configuration.AutoDetectChangesEnabled = true;
    await conn.SaveChangesAsync();
