    [Test]
    public void Test()
    {
        var items = new[]
        {
            new Item {Id = 2, Price = 80.0},
            new Item {Id = 8, Price = 44.25},
            new Item {Id = 14, Price = 43.5},
            new Item {Id = 30, Price = 79.98},
            new Item {Id = 54, Price = 44.24},
            new Item {Id = 74, Price = 80.01}
        };
        var groups = items.GroupByWithTolerance(i => i.Price, 0.02);
        foreach (var itemGroup in groups)
        {
            var groupString = string.Join(", ", itemGroup.Select(i => i.ToString()));
            System.Console.WriteLine($"{itemGroup.Key} -> {groupString}");
        }
    }
    private class Item
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public override string ToString() => $"[ID: {Id}, Price: {Price}]";
    }
