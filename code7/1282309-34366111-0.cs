    public class ShoppingCartViewModel
    {
        public decimal TotalPrice { set; get; }
        public List<Product> CartItems { set; get; }
    }
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
