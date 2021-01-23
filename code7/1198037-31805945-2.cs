    public class Node
    {
        public Node()
        {
            this.Items = new List<Node>();
            this.Parent = null;
            this.Depth = 0;
        }
        public Node Parent { get; set; }
        public List<Node> Items { get; set; }
        public int Depth { get; set; }
    }
    
    public void SetDepths(Node node, int depth)
    {
        node.Depth = depth;
        foreach (var child in node.Items)
            SetDepths(child, depth + 1);
    }
    public void Sort(List<Node> nodes)
    {
        SetDepths(nodes.Single(x => x.Parent == null), 1);
        nodes = nodes.OrderBy(x => x.Depth).ToList();
    }
