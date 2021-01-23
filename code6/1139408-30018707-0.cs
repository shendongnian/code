    public static string Get<TEntity>()
    {
        return Get(typeof(TEntity));
    }
    public static string Get(Type entityType)
    {
        foreach (LocalizableDisplayNameAttributeI attrib in
            entityType.GetCustomAttributes(typeof(LocalizableDisplayNameAttributeI), true))
        {
            return attrib.DisplayName;
        }
        return entityType.Name;
    }
