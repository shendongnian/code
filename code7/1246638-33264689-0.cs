    public class Item
    {
        public Item(int itemNode)
        {
            Node = itemNode;
            Children = new HashSet<Item>();
        }
        public int Node { get; set; }
        public Item Parent { get; set; }
        private HashSet<Item> Children { get; set; }
        public bool Add(Item item)
        {
            item.Parent = this;
            return Children.Add(item);
        }
        public List<Item> Find(Func<Item, bool> predicate)
        {
            var found = new List<Item>();
            if (predicate(this)) found.Add(this);
            Collect(predicate, found);
            return found;
        }
        public void Collect(Func<Item, bool> predicate, List<Item> collected = null)
        {
            collected = collected ?? new List<Item>();
            collected.AddRange(Children.Where(predicate).ToList());
            foreach (var child in Children)
            {
                child.Collect(predicate, collected);
            }
        }
    }
    public class Model : Item //this is your model
    {
        public string Name { get; set; }
        public Model(int itemNode, string name) : base(itemNode)
        {
            Name = name;
        }
        public List<Item> GetNamesMatchingWith(Func<Item, bool> predicate)
        {
            return Find(predicate);
        }
    }
    public class Example
    {
        public static void Main()
        {
            var root = new Model(0, "root");
            var one = new Model(1, "1");
            var two = new Model(2, "2");
            var tree = new Model(3, "3");
            root.Add(one);
            root.Add(two);
            root.Add(tree);
            var a = new Model(4, "a");
            var b = new Model(5, "b");
            two.Add(a);
            two.Add(b);
            var namesMatchingWith = root.GetNamesMatchingWith(x=> x.Parent!=null && x.Parent.Node == 2);
            Console.ReadKey();
        }
    }
