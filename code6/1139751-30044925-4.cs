    public string GetEntityByName(int id, string entityName)
    {
        Type entityType = Type.GetType(entityName);
        var nameProperty = entityType.GetProperty("Name");
        if(nameProperty == null)
            return null;
        using (var context = new MyContext())
        {
            object entity = context.Set(entityType).Find(id);
            return nameProperty.GetValue(entity) as string;
        }
    }
