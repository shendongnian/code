    foreach (var item in Assembly.GetExecutingAssembly().GetTypes()
                                 .Where(x => typeof(Item).IsAssignableFrom(x) && !x.IsAbstract))
    {
        //Handle each item
    }
