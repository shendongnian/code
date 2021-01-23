    List<string> values = "";
    if (yourDictionary.TryGetValue("A", out values))
    {
        Console.WriteLine("Number of elements in {0}: {1}", "A", values.Count);
    }
    else
    {
        Console.WriteLine("Key {0} not found!", "A");
    }
