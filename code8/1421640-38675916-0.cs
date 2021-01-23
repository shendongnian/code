    Assembly assem = typeof(Parent).Assembly;
    foreach (var type in assem.GetTypes().Where(x => x.IsSubclassOf(typeof(Parent))))
    {
        Console.WriteLine($"Parent \"{type.Name}\" found!");
    }
    Console.ReadLine();
