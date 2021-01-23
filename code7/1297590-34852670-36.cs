    public class Item
    {
       public int ItemID { get; set; }
       public int StockAmount { get; set; }
       public string ItemName { get; set; }
    
       public void Validate() 
       { 
          if (this.StockAmount <= 0) throw new Exception ("Out of stock");
          // remaining item validation code
       }
    
    }
    public class Order
    {    
      public int OrderID { get; set; }
      public string OrderName { get; set; }
      public List<Items> OrderItems { get; set; }
      public bool AddItem(Item item)
      {
         OrderItems.Add(item);
      }
    
      public void Validate()
      {
         if(!this.OrderItems.Any()) throw new Exception("Empty order.");        
         // additional order validation code
      }
    
    }
