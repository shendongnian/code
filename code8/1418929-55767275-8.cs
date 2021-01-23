    var dictionary = new VectorDictionary<int>();
    Console.WriteLine($"Added: {dictionary.Add(new Vector(0.5 * 1E-10, 0, 0), 1)}");
    Console.WriteLine($"Added: {dictionary.Add(new Vector(0.6 * 1E-10, 0, 0), 2)}");
    Console.WriteLine($"Added: {dictionary.Add(new Vector(1.6 * 1E-10, 0, 0), 3)}");
    Console.WriteLine($"dictionary.Count: {dictionary.Count}");
    Console.WriteLine($"dictionary.Contains: {dictionary.Contains(new Vector(2.5 * 1E-10, 0, 0))}");
    Console.WriteLine($"dictionary.GetValue: {dictionary[new Vector(2.5 * 1E-10, 0, 0)]}");
