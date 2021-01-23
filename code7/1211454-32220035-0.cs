    public class Node
    {
        public Node(int id, string name, IEnumerable<Node> children)
        {
            Id = id;
            Name = name;
            Children = children;
        }
    
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Node> Children { get; private set; }
    }
