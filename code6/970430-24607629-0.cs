    class Category
    {
      public int CategoryId { get; set; }
      public string Description{ get; set; }
      public string FilePath {get;set;}
      public string ItemName {get;set;}
      public virtual ICollection<Product> Product{ get; set; } 
    }
    class Product
    {
       public int ProductId { get; set; }
       public string name{ get; set; }
       public int CategoryId { get; set; }
       public string Product.image_url {get;set;}
       public int price {get;set;}
       public virtual Category Category{ get; set; }
    }
