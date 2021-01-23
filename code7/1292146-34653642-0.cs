    public class Product
    { 
        public string ProductName {get;set;}
        public int ProductId {get;set;}
    }
    
    public class Store
     {
         public string StoreId { get; set; }
         public string StoreName { get; set; }
         public IList<Product> Products { get; set; }
     }
