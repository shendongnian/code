    foreach (var type in (Assembly.GetExecutingAssembly().GetTypes())
    {
        if (type.IsClass && !type.IsAbstract)
        {
               //registers the type for an interface it implements
        }
    }
