    public struct Item
    {
        public string Name;
        public int Index;
        public string Type;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Item() { Index = 0, Name = "Andy", Type = "O", };
            var item2 = new Item() { Index = 0, Name = "Andy", Type = "X", };
            var item3 = new Item() { Index = 0, Name = "Andy", Type = "X", };
            var items = new[] { item1, item2, item3, };
    
            Console.WriteLine(item1.GetHashCode());  //-1811508281
            Console.WriteLine(item2.GetHashCode());  //-1811508281
            Console.WriteLine(item3.GetHashCode());  //-1811508281
    
            Console.WriteLine(item1.Equals(item2));  // false
            Console.WriteLine(item2.Equals(item3));  // true
    
            var c = items.Distinct().ToList();
    
            Console.WriteLine(c.Count()); // 2
        }
    }
