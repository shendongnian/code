    public void Update(T item)
    {
        var entity = _collection.Find(item.Id);
        if (entity == null)
        {
            return;
        }
    
        _context.Entry(entity).CurrentValues.SetValues(item);
    }
