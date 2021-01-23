    var originalQuery = graphClient
        .Cypher
        .Match("(a:`Entity`)-[r]-(b:`Entity`)")
        .Where("a.DataSpace = b.DataSpace")
        .Return((a, b, r) => new
        {
            FromEntity = a.As<Entity>().EntityName,
            ToEntity = b.As<Entity>().EntityName,
            Relation = r.As<RelationshipObj>().RelType,
        });
