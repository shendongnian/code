    static void Main()
    {
        var items = new List<Item>()
        {
            new Item("Axe", true),
            new Item("Armor", false),
            new Item("Horse", false)
        };
        var remove = items.FirstOrDefault(item =>
        {
            return item.Name.Equals("Armor", StringComparison.InvariantCultureIgnoreCase) &&
                   !item.Active;
        });
        if (remove != null)
            items.Remove(remove);
        Console.WriteLine(string.Join(", ", items.Select(item => item.Name)));
        Console.ReadLine();
    }
    public class Item
    {
        public Item(string name, bool active)
        {
            Name = name;
            Active = active;
        }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
