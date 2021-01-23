    var inputDictionary = new Dictionary<string,string>();
    if (input.Contains(""))
    {
        string name = input.Substring(0, 3);
        string value = input.Substring(4);
        Console.WriteLine("Name:" + name + " " +  "Value:" + value);
        inputDictionary.Add(name, value);
    }
