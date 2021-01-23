    var lookup = new ChildLookup(root);
    ...
    class ChildLookup
    {
        Dictionary<string, Node> nodes;
        public ChildLookup(Node node)
        {
            nodes = new Dictionary<string, Node>();
            AddNodes(node);
        }
        private void AddNodes(Node node)
        {
            nodes[node.Value] = node;
            foreach (var item in node.SubNodes)
                AddNodes(item);
        }
        public IEnumerable<string> GetChildren(string key)
        {
            if (!nodes.ContainsKey(key)) throw new KeyNotFoundException();
            return nodes[key].SubNodes.Select(c => c.Value);
        }
    }
