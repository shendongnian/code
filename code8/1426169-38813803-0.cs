    public void Update(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var item = _collection.Find(item.Id);
    
        if (item == null) throw new ArgumentNullException(nameof(item ));
        _context.Entry(item).CurrentValues.SetValues(entity);
        _context.SaveChanges();
    }
