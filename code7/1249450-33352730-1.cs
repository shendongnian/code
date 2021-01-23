    ArrayList al = new ArrayList();
    al.Add(1);
    al.Add(2);
    // this throws: 
    if (al[0] < al[1])
        Console.WriteLine("First item is smaller");
    // this works:
    IEnumerable<int> coll = al.Cast<int>();
    if (coll.ElementAt(0) < coll.ElementAt(1))
        Console.WriteLine("First item is smaller");
