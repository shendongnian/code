    List<int> input = new List<int> {1, 1, 2, 2, 3, 4};
    var res = new List<int>();
    foreach (int s in input.Where(s => 
                { 
                    Console.WriteLine("lambda: s=" + s);
                    Console.WriteLine("lambda: " + s + " contained in res? " + res.Contains(s));
                    return !res.Contains(s);
                }))
    {
        res.Add(s);
        Console.WriteLine("loop: " + s + " added to res");
        Console.WriteLine();
    }
