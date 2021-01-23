    public void Insert(object entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");
        if (!(entity is IBusinessEntity))
            throw new ArgumentInvalidException("entity is not an IBusinessEntity");
        object existing = Existing(entity);
        if (existing == null)
        {
            _context.Set(entity.GetType()).Add(entity);
            this._context.SaveChanges();
        }
