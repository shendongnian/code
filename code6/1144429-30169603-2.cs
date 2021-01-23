    var userData = JsonConvert.DeserializeObject<MyClass>(json);
    foreach (ListItem item in userData.List)
    {
        Console.WriteLine("a: {0}", item.A);
        Console.WriteLine("b: {0}", item.B);
        Console.WriteLine();
    }
