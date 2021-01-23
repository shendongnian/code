    public class Product
    {
    public int id { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
   
    [ForeignKey("Category")]
    public int CategoryID {get;seT;}
    public virtual Category category { get; set; }
    }
