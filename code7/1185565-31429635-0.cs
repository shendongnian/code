    class Program {
        static void Main(string[] args) {
            var first = new HashSet<Item>() {
                new Item() { Name = "a" },
                new Item() { Name = "b" },
            };
            var second = new HashSet<Item>() {
                new Item() { Name = "b" },
                new Item() { Name = "c" },
            };
            var both = first.Union(second).ToList();
            both.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
    public class Item : IEquatable<Item> {
        public string Name { get; set; }
        public bool IsFound { get; set; }
        public override bool Equals(object that) {
            return that is Item && this.Equals((Item)that);
        }
        public bool Equals(Item that) {
            return this.Name == that.Name;
        }
        public override int GetHashCode() {
            return Name.GetHashCode();
        }
        public override string ToString() {
            return Name;
        }
    }
