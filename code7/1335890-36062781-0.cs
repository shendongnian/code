    public class Order {
      private readonly List<Product> _products = new List<Product>();
      public Product CreateProduct(string name, Price price) {
        var product = new Product(new ProductId(), name, price);
        _products.Add(product);
        return product;
      }
    }
