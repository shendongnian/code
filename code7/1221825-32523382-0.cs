    public static StaticClassForExtensionMethod
    {
        public static AddRange(this ICollection<Node> nodes, params string[] names)
        {
            foreach (var name in names)
                nodes.Add(name);
        }
    }
