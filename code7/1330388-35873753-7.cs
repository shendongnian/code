    public Solution(Graph graph, int colorsCount)
    {
        edges = graph.Vertices.ToList();
        this.colorsCount = colorsCount;
        this.nodes = graph.Nodes.ToList();
    }
