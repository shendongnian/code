    public class Basket {
      private List < BasketItem > lstBasketItems = new List < BasketItem > ();
      public Basket() {
      }
      public void AddItemToBasket(BasketItem addedItem) {
        lstBasketItems.Add(addedItem);
      }
      public decimal CalculateTotal() {
        decimal total = lstBasketItems.Sum(x => Convert.ToDecimal(x.ItemPrice));
        return total;
      }
    }
