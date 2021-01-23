    class Node : IEnumerable<Node> // implement interface to taste
    {
        public Node(string name)
        {
            ...
        }
        public void Add(Node n)
        {
            ...
        }
    }
    var root = new Node("x")
    {   // Each item in this {} is passed to Add
        new Node("y-1")
        {
            new Node("z-1"),
            new Node("z-2")
        },
        new Node("y-2")
    };
