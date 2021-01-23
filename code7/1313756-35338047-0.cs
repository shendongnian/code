	internal class Node
    {
        public Node Parent { get; set; }
        private Node m_child;
        public Node Child
        {
            get { return m_child; }
            set
            {
                m_child = value;
                value.Parent = this;
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Node> nodes = new Dictionary<int, Node>()
            {
                {0, new Node() {Id = 0, Title = "a"}},
                {1, new Node() {Id = 1, Title = "b"}},
                {2, new Node() {Id = 2, Title = "c"}},
                {3, new Node() {Id = 3, Title = "d"}},
                {4, new Node() {Id = 4, Title = "e"}},
                {5, new Node() {Id = 5, Title = "f"}}
            };
            nodes[0].Child = nodes[2];
            nodes[1].Child = nodes[3];
            nodes[2].Child = nodes[3];
            nodes[1].Child = nodes[4];
            nodes[2].Child = nodes[4];
            nodes[3].Child = nodes[5];
            nodes[4].Child = nodes[5];
            Dictionary<int, List<Node>> nbParentNodesDictionary = new Dictionary<int, List<Node>>();
            foreach (KeyValuePair<int, Node> valuePair in nodes)
            {
                Node parent = valuePair.Value.Parent;
                int nbOfParent = 0;
                while (parent != null)
                {
                    nbOfParent++;
                    parent = parent.Parent;
                }
                if (!nbParentNodesDictionary.ContainsKey(nbOfParent))
                {
                    nbParentNodesDictionary[nbOfParent] = new List<Node>();
                }
                nbParentNodesDictionary[nbOfParent].Add(valuePair.Value);
            }
            const int yOffSet = 100;
            foreach (KeyValuePair<int, List<Node>> keyValuePair in nbParentNodesDictionary)
            {
                const int xMax = 500;
                int xOffset = xMax/(keyValuePair.Value.Count+1);
                int x = 0;
                foreach (Node node in keyValuePair.Value)
                {
                    x += xOffset ;
                    Console.Out.WriteLine("id:" + node.Id + " title:" + node.Title + " x:" + x + " y:" + yOffSet * keyValuePair.Key);
                }
            }
        }
    }
