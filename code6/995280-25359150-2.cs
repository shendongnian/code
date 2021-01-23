    var query = graphClient.Cypher
        .Match("(a:`Entity`)-[r*]-(b:`Entity`)")
        .Where("a.DataSpace = b.DataSpace")
        .Return((a, b, r) => new
        {
            FromEntity = a.As<Entity>().EntityName,
            ToEntity = b.As<Entity>().EntityName,
            Relation = r.As<IEnumerable<RelationshipInstance<Dictionary<string,string>>>>(),
        });
    var results = query.Results.ToList();
    foreach (var result in results)
    {
        foreach (var relationship in result.Relation)
        {
            if (relationship.TypeKey == "REL_TO")
            {
                var obj = JsonConvert.DeserializeObject<RelationshipObj>(JsonConvert.SerializeObject(relationship.Data));
                Console.WriteLine(obj.RelType);
            }
        }
    }
