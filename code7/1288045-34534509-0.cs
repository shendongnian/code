    public static class MyModel
    {
        public static Order Order { get; set; }
        public static void NewOrder()
        {
            Order = new Order();
        }
    }
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
