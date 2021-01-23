    public struct Item
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public string Type { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var i = new[] { 
                new Item() { Index = 0, Name = "Andy", Type = "P", },
                new Item() { Index = 0, Name = "Andy", Type = "P", },
                new Item() { Index = 1, Name = "Tom", Type = "M", },
            };
    
            var b = i.Distinct().ToList();
            var c = b.Count(); // 2
        }
    }
