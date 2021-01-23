    var strings = new List<string>();
    strings.Add("John");
    strings.Add("John");
    strings.Add("John");
    strings.Add("Peter");
    strings.Add("Doe");
    strings.Add("Doe");
    foreach (var item in CountOccurences(strings)) {
        Console.WriteLine (String.Format("{0} = {1}", item.Item2, item.Item1));
    }
