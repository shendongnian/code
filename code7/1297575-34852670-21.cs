    public class Item
    {
       public int ItemID { get; set; }
       public string ItemName { get; set; }
    
       public bool IsValid() 
       {
           // item validation code
       }
    
    }
    public class Order
    {
    
      public int OrderID { get; set; }
      public string OrderName { get; set; }
      public List<Items> OrderItems { get; set; }
      public bool AddItem(Item item)
      {
         if(item().IsValid() && this.IsValid())
         {
             //add item to the list
         }
    
      }
    
      public bool IsValid()
      {
         if (orderId <= 0) throw new Exception("Order is required");         
         // additional order validation code
      }
    
    }
