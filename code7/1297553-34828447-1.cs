    public class Order
    {
    
       int OrderID;
       string OrderName;
       List<Items> OrderItems;
       public bool AddItem(Item item)
       {
         //if valid
         if(IsValid(item))
         {
             //add item to the list
         }
         
       }
      public bool IsValid(Item item)
      {
         //validate
      }
      
    }
