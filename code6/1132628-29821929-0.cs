    internal enum InStock
    {
        NeedToOrder,
        NotInStock,
        InStock
    }
    internal class Product
    {
        public string Name { get; set; }
        public InStock Stock { get; set; }
    }
