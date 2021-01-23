    public class Product
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public decimal Price { get; set; }
      public List<ProductStock> Stock { get; set; }
    }
    public class ProductStock
    {
      public int ID { get; set; }
      public string Size { get; set; } // and enum may be better if the possible values wont change
      public int Quantity { get; set; }
    }
