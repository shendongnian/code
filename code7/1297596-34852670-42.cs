    public class Item
    {
       public int ItemID { get; set; }
       public int StockAmount { get; set; }
       public string ItemName { get; set; }
    
       public void Validate(bool validateStocks) 
       { 
          if (validateStocks && this.StockAmount <= 0) throw new Exception ("Out of stock");
          // additional item validation code
       }
    
    }
    public class Order
    {    
      public int OrderID { get; set; }
      public string OrderName { get; set; }
      public List<Items> OrderItems { get; set; }
    
      public void Validate(bool validateStocks)
      {
         if(!this.OrderItems.Any()) throw new Exception("Empty order.");
         this.OrderItems.ForEach(item => item.Validate(validateStocks));        
      }
    
    }
