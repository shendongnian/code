    public class Item
    {
       public int ItemID { get; set; }
       public int StockAmount { get; set; }
       public string ItemName { get; set; }
    
       public void Validate() 
       {
          if (this.ItemId <= 0) throw new Exception("ItemId is required");
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
         this.Validate();
         //add item to the list
      }
    
      public void Validate()
      {
         if (orderId <= 0) throw new Exception("Order is required");         
         // additional order validation code
      }
    
    }
