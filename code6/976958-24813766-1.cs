    class Node : INode
    {
        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }
        private readonly ReadOnlyCollection<INode> _children;
        public ReadOnlyCollection<INode> Children
        {
            get { return _children; }
        }
        public Node(string name, IEnumerable<INode> children)
        {
            _name = name;
            _children = new List<INode>(children).AsReadOnly();
        }
        public Node(string name, params INode[] children)
            : this(name, (IEnumerable<INode>)children)
        { }
    }
