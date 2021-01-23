    public class Item
    {
      public string Name { get; set; }
    
      public virtual ICollection<Stock> Stocks { get; set; }
      public virtual ICollection<Price> Prices { get; set; }
    }
