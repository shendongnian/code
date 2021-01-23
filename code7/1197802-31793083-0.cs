    try
    {
        return _context.Set(entityType).Add(entity);
    }
    catch (NpgsqlException ex)
    {
        if (ex.Code == "42P01")
        {
            CreateEntityTable(entity); //a private method I made
            return _context.Set(entityType).Add(entity);
        }
    }
