    PropertyInfo propInfo 
        = table.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .FirstOrDefault(x => x.Name.Equals("modified ", StringComparison.OrdinalIgnoreCase));
    
    // get value
    if(propInfo != null)
    {
        propInfo.SetValue(table, DateTime.Now);
    }
