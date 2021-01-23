      public static class UtilExtensions {
        // string join that works on any enumerable
        public static string Join<T>(this IEnumerable<T> values, string delim) {
          return String.Join(delim, values.Select(v => v == null ? "null" : v.ToString()));
        }
