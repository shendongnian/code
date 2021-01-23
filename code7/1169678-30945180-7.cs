    var inputs = new List<string> {"11", "12", "13", "14-18", "2-3", "25", "82+", "9"};
    var simplifiedList = Simplify(inputs);
    foreach (string input in simplifiedList)
    {
        Console.WriteLine(input);
    }
