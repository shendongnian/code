    public static void Main(params string[] args)
    {
        var myCustomObjects = new[] {
            new MyCustomObject() { Id = 10, Description = "Hello" },
            new MyCustomObject() { Id = 2, Description = "SO" },
            new MyCustomObject() { Id = 42, Description = "Abcde" }
        };
        var result = myCustomObjects
            .AsQueryable()
            .OrderByField("Description");
        foreach (var r in result)
            Console.WriteLine("{0} - {1}", r.Id, r.Description);
    }
