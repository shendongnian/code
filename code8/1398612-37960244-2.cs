    List<Item> allItems = new List<Item>{ new Item1(), new Item2(), new Item3(), new Item4() };
    HashSet<Type> affectedItems = new HashSet<Type>(){ typeof(Item1), typeof(Item3) };
                
    foreach (Item i in allItems)
    {
        if (affectedItems.Contains(i.GetType()))
        {
            // Do Something
        }
    }
