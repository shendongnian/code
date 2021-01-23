    List<int> initialList = new List<int> { 1 };
    IList<int> readOnly = new ReadOnlyCollection<int>(initialList);
    Console.WriteLine(readOnly.Count); // 1
    Console.WriteLine(readOnly.IsReadOnly); // True
    initialList.Add(2);
    Console.WriteLine(readOnly.Count); // 2
