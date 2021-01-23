    public Node<Owner> CreateOwnerNode(IGraphClient client, Owner owner, Identity identity)
    {
        var query = client.Cypher
            .Create($"(o:{GetLabel<Owner>()} {{owner}})")
            .Create($"(i:{GetLabel<Identity>()} {{identity}})")
            .WithParams(new {owner, identity})
            .Create("(o)-[:HAS]->(i)")
            .Return(o => o.As<Node<Owner>>());
        return query.Results.Single();
    }
    private string GetLabel<TObject>()
    {
        return typeof(TObject).Name;
    }
