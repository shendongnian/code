     public static IEnumerable<string> FilterNamespaces(IEnumerable<string> namespaces)
     => namespaces
      .Where(ns => namespaces
        .Where(n => n != ns)
          .All(n => !Regex.IsMatch(n, $@"{Regex.Escape(ns)}[\.\n]")))
      .Distinct();   
