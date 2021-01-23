    List<int> list = new List<int>();
    list.Add(39);
    list.Add(40);
    list.Add(36);
    list.Add(37);
    list.Add(40);
    list.Add(37);
    list.Add(39);
    var output = list.Select(i => list.Count(a => a == i));
    Console.WriteLine(string.Join(" ",output));
    //"2 2 1 2 2 2 2"
