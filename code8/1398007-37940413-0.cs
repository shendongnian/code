    public class Node
    {
        // Added to store null nodes
        public static HashSet<Node> _nullNodes = new HashSet<Node>();
        Node _rightNode;
        // Changed to property in order to perform 
        // insertion/deletion from set of null nodes
        public Node rightNode
        {
            get { return _rightNode; }
            set
            {   // we don't care about redundant add/remove.
                if (value == null) { _nullNodes.Add(this); }
                else               { _nullNodes.Remove(this); }
                _rightNode = value;
            }
        }
        public Node bottomNode;
        public double x_position;
        public double z_position;
        public double width;
        public double length;
        public bool isOccupied;
        
        // Added for identification
        public object tag;
        public override string ToString()
        {
            return tag == null ? "Un-tagged" : tag.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node n = new Node();
            n.tag = "node 1";
            n.rightNode = new Node();
            n.rightNode.tag = "node 2, null right";
            n.rightNode.rightNode = null;
            Console.Out.WriteLine("Null nodes: ");
            // should print one node
            foreach (var node in Node._nullNodes)
            {
                Console.Out.WriteLine("  " + node);
            }
            n.rightNode.rightNode = new Node();
            // should print no node any more (we replaced null with a node).
            Console.Out.WriteLine("Null nodes: ");
            foreach (var node in Node._nullNodes)
            {
                Console.Out.WriteLine("  " + node);
            }
        }
