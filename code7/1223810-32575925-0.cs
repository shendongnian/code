    int[] array = { 1, 2, 3, 5, 8, 10, 15, 23 };
    var subsets = new List<IEnumerable<int>>();
    
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 2; j < array.Length - i; j++)
        {
            var subset = array.Skip(i).Take(j).ToList();
    
            if (array.Contains(subset.Sum()))
            {
                subsets.Add(subset);
            }
        }
    }
    
    foreach (var subset in subsets)
    {
        Console.WriteLine(string.Join(",", subset));
    }
