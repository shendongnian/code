    public class Node
    {
        public virtual string Field {get {return parent != null ? parent.Field : field;}}
    
        public Node parent;
        public List<Node> children;
    
        public Node()
        {
            children = new List<Node>();
        }
    
        public createChildren()
        {
            for(int i = 0; i < 999999; i++) 
            {
                children.Add(new ChildNode(i, this));
            }
        }
    }
    
    public class ChildNode : Node
    {
        public override string Field {get {return parent.Field;}}
        public ChildNode(Node parent)
        {
            this.parent = parent;
        }
    }
    
    public class RootNode : Node
    {
        public override string Field {get {return "Root";}}
        public RootNode()
        {
            this.parent = null;
        }
    }
