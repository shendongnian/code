    interface INode<TNode> {
        int Id { get; set; }
        TNode connect(TNode node); 
    }
    
    abstract class NodeBase<TNode> : INode<TNode> {
        public int Id { get; set; }
        protected List<TNode> connectedNodes; 
    
        public TNode connect(TNode node) {
            this.connectedNodes.Add(node);
            return this; // Enable chaining.
        }
    }
    
    class Node : NodeBase<Node> { }
    
    class SomeNode : NodeBase<SomeNode> { }
