    QueryContainer MultiMatchQueryContainer(QueryDescriptor<Product> q)
    {
        return q.MultiMatch(qs => qs
            .OnFieldsWithBoost(d => d
                .Add("manufactureNumber", 5.0)
                .Add("number", 4.0)
                .Add("name", 3.0))
            .Type(TextQueryType.BestFields)
            .Query(key));
    }
    QueryContainer NestedMultiMatchQueryContainer(QueryDescriptor<Product> q)
    {
        return q.Nested(n => n
            .Path("subProduct")
            .Query(nq => nq
                .MultiMatch(qs => qs
                    .OnFieldsWithBoost(d => d
                        .Add("subProduct.number", 2.0)
                        .Add("subProduct.name", 1.0))
                    .Type(TextQueryType.BestFields)
                    .Query(key))));
    }
 
