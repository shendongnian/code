    public partial class Product
    {
      public Product(Category category)
       {
          this.Category = category;
       }
     public int ID { get; set; }
     public int ProductID { get; set; }
     public string Name { get; set; }
     public int CategoryID { get; set; }
     public decimal Price { get; set; }
     public int Promotion { get; set; }
     public string Image1 { get; set; }
     public string Image2 { get; set; }
     public string Image3 { get; set; }
     public string Image4 { get; set; }
     public string Description { get; set; }
     public int ClientID { get; set; } 
     public virtual Category Category { get; set; }
    }
