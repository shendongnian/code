    public class Node
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
    
        public Node Parent { get; private set; }
        public ICollection<Node> Children { get; private set; }
        public IEnumerable<Node> Ancestors() {
            Node current = this.Parent;
            while (current != null) {
                yield return current;
                current = current.Parent;                
            }
        }
        public IEnumerable<Node> Descendants() {
            foreach (Node c in this.Children) {
                yield return c;
                foreach (Node d in c.Descendants())
                    yield return d;
            }
        }
    
        // Root node constructor
        public Node() {
            this.Children = new List<Node>();     
        }
    
        // Child node constructor
        public Node(Node parent) : this() {
            this.Parent = parent;
            parent.Children.Add(this);
        }
    }
