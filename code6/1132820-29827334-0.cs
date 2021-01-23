    public static string Join(this IEnumerable<string> @this, string separator, 
      string singleFormat, string multipleFormat)
    {
      var nonEmpty = @this.Where(i => !string.IsNullOrEmpty(i)).ToArray();
      return string.Format
        (
          nonEmpty.Count == 1 ? singleFormat : multipleFormat, 
          string.Join(separator, nonEmpty)
        );
    }
