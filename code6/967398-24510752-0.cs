    public class Node
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
    
        public Node Parent { get; private set; }
        public IEnumerable<Node> Children { get; private set; }
    
        // Make root node
        public Node() {
            this.Children = new List<Node>();
     
        }
    
        // Make child node
        public Node(Node parent) : this() {
            this.Parent = parent;
        }
    }
