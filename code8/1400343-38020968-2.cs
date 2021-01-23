    PropertyInfo idProperty = typeof(Customer).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
    if(idProperty != null) 
    {
        // Yes, it has an Id property!
    }
