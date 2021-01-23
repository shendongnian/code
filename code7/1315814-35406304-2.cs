    public class Product
    {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
   
    [ForeignKey("Category")]
    public int CategoryID {get;set;}
    public virtual Category category { get; set; }
    }
