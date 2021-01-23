    public interface IGraph<TNode, TEdge>
        where TNode : INode
        where TEdge : IEdge
    {
        TNode Root { get; set }
        List<TNode> Nodes { get; set; }
        List<TEdge> Edges { get; set; }
    }
    public interface INode
    {
        List<IEdge> Edges { get; set; }
    }
    public interface INode<TEdge> where TEdge : IEdge
    {
        List<TEdge> Edges { get; set; }
    }
    public interface IEdge
    {
        INode To { get; set; }
        INode From { get; set; }
    }
    public interface IEdge<TNode> where TNode : INode
    {
        TNode To { get; set; }
        TNode From { get; set; }
    }
    public class MyGraph : IGraph<MyNode, MyEdge>
    {
        public MyGraph(MyNode root)
        {
            Root = root;
        }
        public MyNode Root { get; set; }
        public List<MyNode> Nodes { get; set; }
        public List<MyEdge> Edges { get; set; }
    }
    public class MyNode : INode<MyEdge>, INode
    {
        public List<MyEdge> Edges { get; set; }
        List<IEdge> INode.Edges
        {
            get { return this.Edges; }
            set { this.Edges = value; }
        }
    }
    public class MyEdge : IEdge<MyNode>, IEdge
    {
        public MyNode To { get; set; }
        public MyNode From { get; set; }
        INode IEdge.To
        {
            get { return this.To; }
            set { this.To = value; }
        }
        INode IEdge.From
        {
            get { return this.From; }
            set { this.From = value; }
        }
    }
