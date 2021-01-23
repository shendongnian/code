    var lines = System.IO.File.ReadAllLines(@"D:\test.txt");
    var data = new List<List<string>>();
    foreach (var line in lines)
    {
        var split = line.Split(new[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
        data.Add(split.ToList());
    }
