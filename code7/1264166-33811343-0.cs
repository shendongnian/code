    void Method(Type t)
    {
        foreach (PropertyInfo info in t.GetProperties())
        {
            if ((info.Name == "CreatedOn" || info.Name == "ModifiedOn") && info.CanWrite && (DateTime)info.GetValue(p,null) == default(DateTime))
            {
                info.SetValue(p, DateTime.UtcNow, null);
            }
            Method(info.PropertyType);
        }
    }
