     public static IEnumerable<string> FilterNamespaces(IEnumerable<string> namespaces)
    {
      return
      namespaces
      .Where(ns => namespaces
        .Where(n => n != ns)
          .All(n => !Regex.IsMatch(n, $@"{ns}[\.\n]")));
    }
