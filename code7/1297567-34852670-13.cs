    public class Item
    {
       int OrderID;
       int ItemID;
       string ItemName;
    
       public bool IsValid() 
       {
       // item validation code
       }
    
    }
    public class Order
    {
    
      int OrderID;
      string OrderName;
      List<Items> OrderItems;
      public bool AddItem(Item item)
      {
         if(item().IsValid() && this.IsValid())
         {
             //add item to the list
         }
    
      }
    
      public bool IsValid()
      {
         //order validation code
      }
    
    }
