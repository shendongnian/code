    class ItemEqualityComparer : IEqualityComparer<Item> {
      public Boolean Equals(Item item1, Item item2) {
        return item1.Name == item2.Name
          && item1.Book == item2.Book
          && item1.Page == item2.Page;
      }
      public Int32 GetHashCode(Item item) {
        unchecked {
          const Int32 Multiplier = -1521134295;
          var hash = -175858345;
          hash = hash*Multiplier + item.Name.GetHashCode();
          hash = hash*Multiplier + item.Book.GetHashCode();
          hash = hash*Multiplier + item.Page.GetHashCode();
          return hash;
        }
      }
    }
