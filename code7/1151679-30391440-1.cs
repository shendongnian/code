    public async Task<string> GetRelatedObjectsAsJson(string sourceObject, string userId)
    {
        var resQuery = GraphDB.Cypher
            .Match(string.Format("(src:{0})--(usr:User {{ Id:{{userId}} }})", sourceObject))
            .WithParam("userId", userId)
            .Return(src => src.As<Node<string>>());
        var result = await resQuery.ResultsAsync;
        var output = result.Select(node => JsonConvert.DeserializeObject<dynamic>(node.Data)).ToList();
        return JsonConvert.SerializeObject(output);
    }
