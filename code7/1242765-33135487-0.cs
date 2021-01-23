    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<Item>
            {
                new Item { task = 1, supplier = 77, source = 3 },
                new Item { task = 2, supplier = 71, source = 3 },
                new Item { task = 3, supplier = 77, source = 1 },
                new Item { task = 4, supplier = 77, source = 2 },
                new Item { task = 5, supplier = 72, source = 3 },
                new Item { task = 6, supplier = 72, source = 2 },
                new Item { task = 7, supplier = 77, source = 3 },
                new Item { task = 8, supplier = 72, source = 3 },
                new Item { task = 9, supplier = 71, source = 1 },
                new Item { task = 10, supplier = 72, source = 3 }
            };
            
            var groupBy = list.GroupBy(x => new { first = x.source, second = x.supplier}).Select(x => new { name = x.Key, items = x.Count() });
            
            foreach (var g in groupBy)
            {
                Console.WriteLine(g);
            }
            
            
        }
        
    }
    
    public class Item
    {
        public int task;
        public int supplier;
        public int source;
        
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", task, supplier, source);
        }
    }
