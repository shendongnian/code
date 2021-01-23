    protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
                           IDictionary<object, object> items)
    {
        items.Add("Context", this);
        return base.ValidateEntity(entityEntry, items);
    }
