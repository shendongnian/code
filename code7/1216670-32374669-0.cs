    public void Update(object entity, string typeName)
    {
        var type = Type.GetType(typeName);
        DbContext.Set(type).Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
        DbContext.SaveChanges();
    }
