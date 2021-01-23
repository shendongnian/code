    var test = new List<string>();
    for (var x = 1; x <= 5; x++)
    {
        test.Add("#" + x + " element");
        Console.WriteLine(test[x]);
    }
    test.RemoveAt(3);
    for (var x = 0; x < test.Count; x++)
    {
        Console.WriteLine(test[x]);
    }
