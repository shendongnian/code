    public class Item
    {
       public Item(int orderId, int itemId)
       {
           if (orderId <= 0) throw new ArgumentException("Order is required");
           if (itemId <= 0) throw new ArgumentException("ItemId is required");
    
          OrderId = orderId;
          ItemId = itemId;
       }
    
       public int OrderID { get; private set; }
       public int ItemID { get; private set; }
       public string ItemName { get; set; }
    }
