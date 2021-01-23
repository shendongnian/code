    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
    {
        foreach (var prop in type.GetProperties())
        {
            //Iterating properties
        }
        foreach (var prop in type.GetFields())
        {
            //Iterating fields
        }
        foreach (var prop in type.GetMethods())
        {
            //Iterating methods
        }
        //Or iterate through all members
        foreach (var member in type.GetMembers())
        {
            //Iterating properties
        }
    }
