    public class Root : Node
    {
        public int ParentID;
        public Root(int id) : base(null, null, null)
        {
            ParentID = id;
        }
    }
    
    public class Parameter : Node
    {
        public string ParameterType;
        public Parameter(string paramName, string paramType, Node fromParent = null) : base(paramName, null, fromParent)
        {
            ParameterType = paramType;
        }
    }
    public class Value : Node
    {
        public string Unit;
        public Value(int val, string unit, Node fromParent = null) : base(null, val, fromParent)
        {
            Unit = unit;
        }
    }
