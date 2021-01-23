    var test = new List<string>();
    for (var x = 1; x <= 5; x++)
    {
        test.Add(String.Format("#{0} element", x));
    }
    Console.WriteLine(String.Join(" ", test);
    test.RemoveAt(3);
    Console.WriteLine(String.Join(" ", test);
