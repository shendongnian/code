      public static class PriceExtensions {
        //TODO: may be "GetDefaultPrice" is a better name for the method
        public static IEnumerable<Price> GetPrice(this IPrice price) {
          if (null == price)
            throw new ArgumentNullException("price");
    
          return price.GetPrice((DateTime?)null);
        }
      }
