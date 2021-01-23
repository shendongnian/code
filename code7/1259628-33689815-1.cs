    public IEnumerable<Result> GetPath(IEnumerable<string> rootKeys, GraphRelationship relationship)
    {
        var query = new CypherFluentQuery(Client)
                    .Unwind(rootKeys, "entityRootKey")
                    .Match(string.Format("p = (root)-[r:{0}*0..]->()", relationship.Name))
                    .Where("root.CompositeKey = entityRootKey")
                    .With("{Root:root, Nodes: nodes(p), Length: length(p)} as res")
                    .Return((res) => res.As<Result>())
                    .OrderByDescending("res.Length")
                    .Limit(10);
        var results = query.Results;
        return results;
    }
