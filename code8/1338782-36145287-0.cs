    public class Level1
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public IEnumerable<Level2> Items { get; set; }
    }
    public class Level2
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    public IEnumerable<Level1> Items
    {
        get
        {
            return Enumerable.Range(1, 10)
                .Select(x => new Level1
                {
                    Key = x,
                    Name = $"Level 1 Item {x}",
                    Items = Enumerable.Range(1, 10)
                        .Select(y => new Level2
                        {
                            Key = y,
                            Name = $"Level 2 Item {y}",
                        })
                });
        }
    }
