    if (teamLists.Count == region.Count)
    {
        for (int i = 0; i < teamLists.Count; i++)
        {
            Console.WriteLine("{0} is in the {1} region", teamLists[i], region[i]);
        }
    }
    else
    {
        Console.WriteLine("Items in the collections are not matching");
    }
