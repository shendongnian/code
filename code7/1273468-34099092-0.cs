    var dict = new Dictionary<string, string>();
    dict.Add("ValidKey", "Valid Value");
    string validKey = "ValidKey";
    string invalidKey = "InvalidKey";
    //Outputs "Valid Value"
    if (dict.ContainsKey(validKey))
    {
        Console.WriteLine(dict[validKey]);
    }
    //Outputs nothing and throws no exception
    if (dict.ContainsKey(invalidKey))
    {
        Console.WriteLine(dict[invalidKey]);
    }
