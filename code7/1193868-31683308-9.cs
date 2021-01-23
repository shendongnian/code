        private static List<List<Node>> getAllPaths(Node n)
        {
            if (n.Dependencies == null || n.Dependencies.Count == 0)
                return new List<List<Node>> { new List<Node> { n }};
            List<List<Node>> allPaths = n.Dependencies.SelectMany(getAllPaths).ToList();
            allPaths.ForEach(path => path.Insert(0, n));
            return allPaths;
        }
        private static int getMaxDepth(Node n)
        {
            return getAllPaths(n).Max(p => p.Count);
        }
