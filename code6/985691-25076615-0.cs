    private static IEnumerable<string> GetAllowedNamespaces(Type type)
    {
        const string System = "System";
        string thisNamespace = type.Namespace;
        HashSet<string> hashset = new HashSet<string>();
        hashset.Add(thisNamespace);
        hashset.Add(System);
        var parts = thisNamespace.Split('.');
        if (parts.Length > 1)
        {
            string previous = string.Empty;
            foreach (var part in parts)
            {
                var current = string.IsNullOrEmpty(previous)
                    ? part
                    : string.Format("{0}.{1}", previous, part);
                previous = current;
                hashset.Add(current);
            }
            previous = string.Empty;
            foreach (var part in new[] { System  }.Concat(parts.Skip(1)))
            {
                var current = string.IsNullOrEmpty(previous)
                    ? part
                    : string.Format("{0}.{1}", previous, part);
                previous = current;
                hashset.Add(current);
            }
        }
        return hashset;
    }
