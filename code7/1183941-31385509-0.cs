    // Get the list of names to add
    var newNames = dbContext.db_client_1.Select(e => e.name).Except(dbContext.db_central.Select(e => e.name));
    // Convert the names to a list of entity objects and add them.
    dbContext.db_central.Add(newNames.Select(e => new db_central { name = e.name });
    dbContext.SaveChanges();
