      public static class ListExtensions {
        public void DeleteItemFront<T>(this IList<T> list) {
          list.RemoveAt(0);
        } 
        ...
      } 
