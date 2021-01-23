    static class CountExtensions {
    
      public static dynamic ToCounts(this IEnumerable<TypeCount> typeCounts) {
        return new CountsDictionary(typeCounts);
      }
    
    }
