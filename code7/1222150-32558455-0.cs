    List<long> validKeys = ...;
    Bar barAlias = null
    
    // get the count of matching Attributes
    var subquery = QueryOver.Of<Bar>()
        .Where(p = > p.Id == barAlias.Id)
        .JoinQueryOver<Baz>(p => p.BazList)
            .WhereRestrictionOn(baz => baz.Id).In(validKeys))
        .Select(Projections.RowCount());
    
    var matchesQuery = QueryOver.Of(() => barAlias)
        .WithSubquery.WhereValue(validKeys.Count).Eq(subquery)
        ..Select(Projections.Id());
    
    var results = sessioni.QueryOver<Foo>()
        .WithSubquery.WhereProperty(foo => foo.Bar.Id).In(matchesQuery)
        .List();
