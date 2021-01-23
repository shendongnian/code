    foreach (var item in filter)
    {
        foreach (var innerItem in item)
        {
             Console.WriteLine(innerItem.IsAddOn);
             Console.WriteLine(innerItem.Country);
             //and so on..
        }
    }
