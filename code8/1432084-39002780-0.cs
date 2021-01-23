    string flags = "red yellow blue";
    var eflags = flags.Split()
                      .Select(s => (Properties)Enum.Parse(typeof(Properties), s))
                      .Aggregate((a, e) => a | e);
    Console.WriteLine(eflags);
    Console.WriteLine((int)eflags);
