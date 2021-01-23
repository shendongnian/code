    IEnumerable<string> names = typeof(MyClass ).GetProperties().Select(prop => prop.Name);
    foreach (var name in names)
    {
       Console.WriteLine(name);
    }
