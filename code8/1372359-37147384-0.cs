    class Graph
    {
        List<Node> nodes;
        List<Edge> edges;
    
        public Graph( ... ) { /* populate lists */ }
        public void AddEdges(params Edge[] edges) {
            foreach (var edge in edges) {
                edge.Node1.Parent = this;
                edge.Node2.Parent = this;
            }
        }
    }
    
    class Node {
        public Graph Parent { get; set; }
    
        public List<Node> GetNeighbours()
        {
            var neighbors = new List<Node>();
            foreach(var edge in parent.Edges) { 
                if (edge.Node1 == this && !neighbors.Contains(edge.Node2)) {
                    neighbors.Add(edge.Node2);
                }
                else if (edge.Node2 == this && !neighbors.Contains(edge.Node1)) {
                    neighbors.Add(edge.Node1);
                }
            }
        }
    }
    class Edge {
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }
    }
