       class Program
        {
            static void Main(string[] args)
            {
                var first = new List<Item> { new Item("one"), new Item("two") };
                var second = new List<Item> { new Item("two"), new Item("three") };
                var combined = new List<Item>();
    
                combined.AddRange(first);
                
                foreach (var item in second)
                {
                    int index = combined.FindIndex(x => x.name == item.name);
                    if (index <= 0)
                    {
                        combined.Add(item);
                    }
                    
                }
    
                foreach (var item in combined)
                {
                    Console.WriteLine(item.name);
                }
                
            }
    
            class Item
            {
                public string name;
                public Item(string name)
                {
                    this.name = name;
                }
            }
        }
