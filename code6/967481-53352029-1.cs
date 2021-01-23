    List<int> numberList = new List<int>() { 3, 3, 3, 4, 5, 5, 7, 7, 9, 9 };
     var distinctTest = numberList 
                    .GroupBy(i => i)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key);
    
    foreach (var item in distinctTest)
    {
        Console.WriteLine(item);
    }
