    var list = new List<string>(new[] { "1", "2", "3", "a", "b", "a", "b", "c", "1", "2" });
    var sublist = new List<string>(new[] { "a", "b", "c" });
    var a = string.Join("#", list);
    var b = string.Join("#", sublist);
    var result =
        new List<string>(a.Replace(b, string.Empty).Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries));
    foreach (var item in result)
    {
        Console.Write(item + ",");
    }
