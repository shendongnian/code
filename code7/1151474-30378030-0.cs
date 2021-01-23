    Type t = typeof ( YourType );
    foreach ( PropertyInfo p in t.GetProperties () )
    {
        if ( p.PropertyType.IsInterface )
        {
            // p is an interface property
        }
    }
