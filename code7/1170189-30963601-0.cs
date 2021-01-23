    var entry = _context.Entry(entity);
    entry.State = EntryState.Modified;
    entry.Property(m => m.Property).IsModified = false;
    _context.Configuration.ValidateOnSaveEnabled = false;
    _context.SaveChanges();
    _context.Configuration.ValidateOnSaveEnabled = true;
