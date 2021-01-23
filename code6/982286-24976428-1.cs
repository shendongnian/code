    public abstract Graph<TNode, TEdge>
        where TNode : BaseNode<TEdge>
        where TEdge : BaseEdge<TNode>
    {
        public TNode Root { get; set; }
        public List<TNode> Nodes { get; set; }
        public List<TEdge> Edges { get; set; }
    }
    public abstract BaseNode<TEdge> where TEdge : BaseEdge<BaseNode<TEdge>>
    {
        public List<TEdge> Edges { get; set; }
    }
    public abstract BaseEdge<TNode> where TNode : BaseNode<BaseEdge<TNode>>
    {
        public TNode To { get; set; }
        public TNode From { get; set; }
    }
    public class MyNode : BaseNode<TEdge> where TEdge : BaseEdge<MyNode>
    {
        ...
    }
    public class MyEdge : BaseEdge<TNode> where TNode : BaseNode<MyEdge>
    {
        ...
    }
    public class MyGraph : Graph<MyNode, MyEdge>
    {
        ...
    }
    public MyGraph<MyNode, MyEdge> g = new MyGraph<MyNode, MyEdge>();
    List<MyEdge> edges = g.Nodes[0].Edges;
    MyNode toNode = g.Edges[0].To;
