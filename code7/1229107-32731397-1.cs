    // raw SQL query
    var query = session
        .CreateSQLQuery("Select " +
                        " SomColumn AS FirstAlias, " +
                        " SomComputedColumn AS SecondAlias " +
                        " FROM mySchema.MyTable" +
                        " join, where, order by..... "
                       );
    
    // here we set transformer (check the aliases)
    query.SetResultTransformer(Transformers.AliasToBean<MyDto>());
    
    // and there is nice C# result
    var list = query.List<MyDto>();
