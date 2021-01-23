    public class Root : Node
    {
        public Root() : base(null, null, null)
        {
    
        }
    }
    
    public class Parameter : Node
    {
        public Parameter(string paramName, Node fromParent = null) : base(paramName, null, fromParent)
        {
            
        }
    }
    public class Value : Node
    {
        public Value(int val, Node fromParent = null) : base(null, val, fromParent)
        {
    
        }
    }
