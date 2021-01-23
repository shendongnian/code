    foreach (KeyValuePair<string, Student> kvp in root.Result)
    {
        Console.WriteLine(kvp.Key);
        Console.WriteLine("Age: " + kvp.Value.Age);
        Console.WriteLine("School: " + kvp.Value.School);
        Console.WriteLine();
    }
