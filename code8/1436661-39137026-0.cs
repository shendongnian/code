    public class Product {
       public Product() {
          Details = new List<ProductDetails>();
       }
       public string Name {get; set;}
       public ICollection<ProductDetails> Details {get; private set;}
    }
    public class ProductDetails {
       public string SomeDetailedText {get; set;}
    }
