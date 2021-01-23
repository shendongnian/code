    public class Item
    {
       public int ItemID { get; set; }
       public string ItemName { get; set; }
    
       public bool IsValidForOrder(Order order) 
       {
       // order-item validation code
       }
    
    }
