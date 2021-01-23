    // 
    var local = _context.Set<YourEntity>()
        .Local
        .FirstOrDefault(entry => entry.Id.Equals(entryId));
    
    // check if local is not null 
    if (!local.IsNull()) // I'm using a extension method
    {
        // detach
        _context.Entry(local).State = EntityState.Detached;
    }
    // set Modified flag in your entry
    _context.Entry(entryToUpdate).State = EntityState.Modified;
    // save 
    _context.SaveChanges();
