    public Solution(Graph graph, int colorsCount)
    {
        //I don't actually see you modifying edges, so maybe you could 
        //get away with "edges = graph.Vertices;" and save on RAM.
        edges = graph.Vertices.Select(old => old.Clone()).ToList();
        this.colorsCount = colorsCount;
        this.nodes = graph.Nodes.Select(old => old.Clone()).ToList();
    }
