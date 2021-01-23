    public string GetEntityByName<TEntity>(int id)
    {
        var nameProperty = typeof(TEntity).GetProperty("Name");
        if(nameProperty == null)
            return null;
        using (var context = new MyContext())
        {
            object entity = context.Set<TEntity>.Find(id);
            return nameProperty.GetValue(entity) as string;
        }
    }
