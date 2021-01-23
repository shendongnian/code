    var originalStatus = original.GetType().GetProperty("isDeleted").GetValue(original);
    updated.GetType().GetProperty("isDeleted").SetValue(original, true);
    
    _dbSet.Attach(original);
    _context.Entry(original)
    			.CurrentValues
    			.SetValues(updated);
    _context.Entry(original).State = EntityState.Modified;
