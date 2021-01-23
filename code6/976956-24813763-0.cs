    public partial class TreeLike {
        public SomeType1 SomeTreeProperty1 { get; private set; }
        public SomeType2 SomeTreeProperty2 { get; private set; }
        public SomeType3 SomeTreeProperty3 { get; private set; }
        private List<NodeLike> _Nodes = new List<NodeLike>();
        public ReadOnlyCollection<NodeLike> Nodes {
            get {
                return _Nodes.AsReadOnly();
            }
        }
        TreeLike() {
            NodeLike n1 = new NodeLike();
            NodeLike n0 = new NodeLike(n1);
            _Nodes.Add(n0);
        }
    }
    public class NodeLike {
        public SomeType1 SomeNodeProperty { get; private set; }
        private List<NodeLike> _Children = new List<NodeLike>();
        public ReadOnlyCollection<NodeLike> Children {
            get {
                return _Children.AsReadOnly();
        }
        public NodeLike(params NodeLike[] children) {
            _Children = children.ToList();
        }
    }
