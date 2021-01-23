    var items = new List<int> {1, 2, 3, 1, 7, 4, 6, 1, 9};
        
    var query = items
        .Skip(1)
        .Distinct()
        .Where(x => x != items.First())
        .OrderBy(x => x);
    
    foreach (int item in query)
    {
        Console.WriteLine(item);
    }
