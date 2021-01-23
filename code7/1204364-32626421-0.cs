    class Node
    {
        readonly List<Node> children;
        readonly String name;
        
        public Node(String name)
        {
            this.children = new List<Node>();
            this.name = name;
        }
        
        public Node AddChild(Node node)
        {
            children.Add(node);
            return this;
        }
        
        public Node InsertChild(int index, Node node)
        {
            children.Insert(index, node);
            return this;
        }
        
        public Int32 Length
        {
            get { return children.Count; }
        }
        
        public Node this[Int32 index]
        {
            get { return children[index]; }
        }
        
        public Int32 IndexOf(Node node)
        {
            return children.IndexOf(node);
        }
        
        public Node RemoveChild(Node node)
        {
            children.Remove(node);
            return this;
        }
        
        public IEnumerable<Node> Children
        {
            get { return children.AsEnumerable(); }
        }
        
        public override String ToString()
        {
            var content = new String[1 + children.Count];
            content[0] = name;
            
            for (int i = 0; i < children.Count; )
            {
                var childs = children[i].ToString().Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                content[++i] = "+ " + String.Join(Environment.NewLine + "  ", childs);
            }
            
            return String.Join(Environment.NewLine, content);
        }
    }
