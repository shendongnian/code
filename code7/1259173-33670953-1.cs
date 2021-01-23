    public class Inventory : EntityCollection<Product, string>
    {
        public override Product Get(string id) { ... }
        public override void Add(Product item) { ... }
        ...
    }
