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
    List<MyEdge> edges = g.nodes[0].inputs;
    MyNode toNode = g.edges[0].To;
