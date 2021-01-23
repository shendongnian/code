    public static class FilteringOutObjectFromCompositeList
    {
        public class Item
        {
            public Item()
            {
                children = new List<Item>();
            }
            public string name { get; set; }
            public int size { get; set; }
            public IList<Item> children { get; set; }
        }
        private static void PruneTree(IList<Item> items)
        {
            for (int i = items.Count - 1; i >= 0; i--) {
                Item item = items[i];
                if (item.name != "Test") {
                    PruneTree(item.children);
                    if (item.children.Count == 0) {
                        items.RemoveAt(i);
                    }
                }
            }
        }
        public static void Test()
        {
            var root = new Item {
                name = "Ford",
                children = new List<Item> {
                     new Item {
                        name = "Figo",
                        children = new List<Item> {
                            new Item { name= "Test", size= 3938 },
                            new Item { name= "Test1", size= 3938 },
                            new Item {
                                name= "Test2",
                                children = new List<Item> {
                                    new Item { name= "Test-1-1", size= 3938 },
                                    new Item { name= "Test-1-2", size= 3938 }
                                }
                            }
                        }
                    },
                    new Item {
                        name= "Test",
                        children=new List<Item> {
                            new Item { name= "Test1", size= 3938 },
                            new Item { name= "Test2", size= 3938 },
                            new Item { name= "Test3", size= 3938 }
                        }
                    }
                }
            };
            PrintTree(root, 0);
            PruneTree(root.children);
            Console.WriteLine("----------------------");
            PrintTree(root, 0);
            Console.ReadKey();
        }
        private static void PrintTree(Item item, int level)
        {
            PrintIndent(level);
            Console.Write("name = " + item.name);
            if (item.size != 0) {
                PrintIndent(level);
                Console.Write("size = " + item.size);
            }
            Console.WriteLine();
            foreach (var child in item.children) {
                PrintTree(child, level + 1);
            }
        }
        private static void PrintIndent(int level)
        {
            Console.Write(new String(' ', 4 * level));
        }
    }
