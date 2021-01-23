    var entity = await _context.Modules
        .Where(e => e.Id == updated.Id)
        .FirstOrDefaultAsync();
    if (entity == null) {
      ... // throw exception about record not existing in the database
    }
    if (BitConverter.ToInt64(entity.RowVersion, 0) != BitConverter.ToInt64(updated.RowVersion, 0)) {
      ... // throw exception about record having been updated in the database
    }
    ... // your existing code to update the entity can go here
