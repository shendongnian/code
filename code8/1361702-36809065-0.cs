    public sealed class Node<T>
    {
        public Node(T value) { Value = value; }
        public T Value { get; }
        public IEnumerable<Node<T>> Children => _children;
        public void Add(Node<T> child)
        {
            _children.Add(child);
        }
        readonly List<Node<T>> _children = new List<Node<T>>();
    }
