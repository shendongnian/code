    Dictionary<string, MyClass> dictionary = new MyClass[]
    {
        new MyClass("Name 1", "Second Value 1"),
        new MyClass("Name 2", "Second Value 2"),
        new MyClass("Name 3", "Second Value 3")
    }.ToDictionary(c => c.NameProperty, c => c);
