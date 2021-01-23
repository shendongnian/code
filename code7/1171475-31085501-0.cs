    public class Node
    {
        public Node()
        {
        }
        public Node(Node node)
            : this()
        {
            if (node == null)
                return;
            if (node.Children != null)
                this.Children = new List<Node>(node.Children);
            this.Parent = new Node(node.Parent);
            this.RegionName = nodeData.RegionName;
            this.RegionValue = nodeData.RegionValue;
            this.Level = nodeData.Level;
        }
        public List<Node> Children = new List<Node>();
        public Node Parent;
        public string RegionName;
        public double? RegionValue;
        public int Level;
    }
