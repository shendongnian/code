    static void Main()
    {
        var items = new List<Item>()
        {
            new Item("Axe"),
            new Item("Armor"),
            new Item("Horse")
        };
        items.Remove(items.First(item => 
            item.Name.Equals("Armor", StringComparison.InvariantCultureIgnoreCase)));
        Console.WriteLine(string.Join(", ", items.Select(item => item.Name)));
        Console.ReadLine();
    }
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
