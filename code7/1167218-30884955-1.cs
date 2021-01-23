    public static void AddNodes(GraphClient client, List<MyNode> nodes)
    {
        client.Cypher
           .Create("(n:Node {nodes})")
           .WithParams(new { nodes })
           .ExecuteWithoutResults();
    }
