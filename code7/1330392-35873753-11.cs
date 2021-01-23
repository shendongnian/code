    class Solution
    {
        private int colorsCount;
        private List<Vertex> edges;
        private List<Node> nodes;
    
        private Solution(List<Vertex> edges, List<Node> nodes, int colorsCount)
        {
            this.colorsCount = colorsCount;
            this.edges = edges;
            this.nodes = nodes.Select(old => old.Clone()).ToList();
        }
    
        public Solution(Graph graph, int colorsCount)
        {
            edges = graph.Vertices;
            this.colorsCount = colorsCount;
            this.nodes = graph.Nodes.Select(old => old.Clone()).ToList();
        }
    
        public void assignColor(int index, int color)
        {
            nodes[index].color = color;
        }
    
    }
    class Node
    {
        public int number { get; set; }
        public int color { get; set; }
        public Node(int number)
        {
            this.number = number;
        }
        public Node() { }
        public Node Clone()
        {
            var newNode = new Node();
            newNode.number = this.number;
            newNode.color = this.color;
            return newNode;
        }
    }
