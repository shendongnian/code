      class Program2
        {
            class ConsumableItems
            {
                new public List<string> itemNames = new List<string>() { "Apple", "Orange", "Grapes" };
                new public List<int> itemEffects = new List<int>() { 15, 30, 40 };
    
                public Dictionary<string, int> values = new Dictionary<string, int>()
                {
                    {"Apple", 15},
                    {"Orange", 30},
                    {"Grapes", 40}
                };
            }
    
            static void Main()
            {
                ConsumableItems items = new ConsumableItems();
    
                string key = Console.ReadLine();
    
                Console.WriteLine("\n\n\n");
    
                Console.WriteLine(key + "   " + items.values[key]);
    
                Console.ReadKey();
            }
        }
