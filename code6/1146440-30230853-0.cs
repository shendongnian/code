    List<int> list1 = new List<int>() { 18, 13, 22, 24, 20, 20, 27, 31, 25, 28 };
    List<int> list2 = new List<int>() { 18, 13, 22, 24, 20, 20, 20, 27, 31, 25, 28, 86, 78, 25 };
    
    // Remove elements of first list from second list
    list1.ForEach(l => list2.Remove(l));
    list2 = list2.Distinct().ToList();
    
    list2.ForEach(d => Console.WriteLine(d));
    Console.Read();
