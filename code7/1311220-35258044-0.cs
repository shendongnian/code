     public static IEnumerable<string> FilterNamespaces(IEnumerable<string> namespaces)
    {
      var rx = @"{0}[\.\n]";
      return
      namespaces
      .Where(ns => namespaces
        .Where(n => n != ns)
          .All(n => !Regex.IsMatch(n, string.Format(rx, ns))));
    }
