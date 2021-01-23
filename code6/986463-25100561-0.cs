    public class ProductCategory
    {
       public int CategoryId { get; set; }
       public string CategoryName { get; set; }
    }
    public class Product
    {
       public Product()
       {
          Categories = new List<ProductCategory>();
       }
       public int ProductId {get;set;}
       public string ProductName { get; set; }
       public IEnumerable<ProductCategory> Categories { get; set; }
    }
