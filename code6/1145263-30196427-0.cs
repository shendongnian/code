    public class Node {
    public int Id { get; set; }
    /** Properties omitted for sake of brevity **/
    private int _parentNodeId;
    public int ParentNodeId { get {return _parentNodeId;}
    set
    {
        _parentNodeId = value;
        ParentNode = GetParentNodePropertyValues(_parentNodeId);
    } 
    }
    public Node ParentNode { get; private set; }
    }
