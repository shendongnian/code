    public interface INode
    {
        
    }
    public interface IEdge
    {
        
    }
    public abstract class Graph<TNode, TEdge>
        where TNode : BaseNode<TEdge>
        where TEdge : BaseEdge<TNode>
    {
        public TNode Root { get; set; }
        public List<TNode> Nodes { get; set; }
        public List<TEdge> Edges { get; set; }
    }
    public abstract class BaseNode<TEdge> : INode where TEdge: IEdge
    {
        List<TEdge> inputs;
        public List<TEdge> Inputs
        {
            get
            {
                return inputs;
            }
        }
        public abstract float process();
    }
    public abstract class BaseEdge<TNode> : IEdge where TNode: INode
    {
        TNode from;
        TNode to;
        public TNode To
        {
            get
            {
                return to;
            }
        }
        public TNode From
        {
            get
            {
                return from;
            }
        }
        public abstract float process();
    }
    public class ConcreteNode : BaseNode<ConcreteEdge>
    {
        public override float process()
        {
            return 0;
        }
    }
    public class ConcreteEdge : BaseEdge<ConcreteNode>
    {
        public override float process()
        {
            return 0;
        }
    }
    public class ConcreteGraph : Graph<ConcreteNode, ConcreteEdge>
    {
    }
