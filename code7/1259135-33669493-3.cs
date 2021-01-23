    object obj = new List<int> { 1, 2, 3 };
    IEnumerable res = obj as IEnumerable;
    List<string> result = res.Cast<object>().Select(e => e.ToString()).ToList();
    foreach (var e in result)
        Console.WriteLine(e);
