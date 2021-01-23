    static class CountExtensions {
    
      public static dynamic ToCounts(this IDictionary<Int32, Int32> counts) {
        return new CountsDictionary(counts);
      }
    
    }
