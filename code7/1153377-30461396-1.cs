    Test test = new Test();
    var output = test.CreateGroups(test.TestInput);
    foreach (List<string> list in output)
    {
        string group = "Group:\r\n";
        foreach (string item in list)
            group += "\t" + item + "\r\n";
        Console.WriteLine(group);
    }
