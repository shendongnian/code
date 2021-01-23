    public IEnumerable<GenNode> GetRelatedObjects(string sourceObject, string userId){
    var resQuery = GraphDB.Cypher
        .Match("(src:" + sourceObject + ")--(usr:User { Id:{userId} })")
        .WithParam("userId", userId)
        .With("src, properties(src) as prop")
        .Return((src,prop) => new GenNode
        {
          Id = src.Id(),
          Labels = src.Labels(),
          Properties = prop.As<Dictionary<Object,Object>>()
        });
        
      var result = await resQuery.ResultsAsync;
    
      return result;
    }
