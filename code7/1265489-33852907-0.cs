    public class Item {
        private readonly string name;
        public string Name { get { return name; } }
        public int Quantity { get; set; }
        
        private readonly Decimal price;
        public Decimal Price { get { return price; } }
        public Item(string name, int qty, Decimal price) {
            this.name = name;
            this.Quantity = qty;
            this.price = price;
        }
        public override string ToString() {
            // You can mess with the formatting of it, this just provides an example
            return string.Format("{0}\t{1}\t{2}", Quantity, name, Price * Quantity);
        }
    }
