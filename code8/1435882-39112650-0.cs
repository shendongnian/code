    void CreateRandomGraph(IList<Node> nodes, int maxConnections)
    {
        var rnd = new Random();
        foreach (Node node in nodes)
        {
            int numConnections = (int)(rnd.NextDouble() * maxConnections);
            for (int i = 0; i < numConnections; i++)
            {
                //Find a random node to connect to
                int idx = (int)(rnd.NextDouble() * nodes.Count);
                node.ConnectTo(nodes[idx]);
            }
        }
    }
