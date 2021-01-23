    public class BasketItem {
      
      private string itemName = string.Empty;
      private decimal itemPrice = 0;
      public string ItemName {
        get {
          return itemName;
        }
        set {
          itemName = value;
        }
      }
      public decimal ItemPrice {
        get {
          return itemPrice;
        }
        set {
          itemPrice = value;
        }
      }
    }
