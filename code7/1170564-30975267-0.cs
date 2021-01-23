    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add("Volvo-1.8", "Volvo");
    dict.Add("Volvo-2.0", "Volvo");
    dict.Add("Ford-BMax", "Ford");
    string value;
    if(dict.TryGetValue("Volvo-1.8", out value))
    {
        Console.WriteLine("Found: " + value);
    }
