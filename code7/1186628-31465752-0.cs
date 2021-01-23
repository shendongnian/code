    // the path part of the query. OR together all the locations
    var pathFilter = PredicateBuilder.False<SearchResultItem>();
    pathFilter = pathFilter.Or(i => i.Paths.Contains(pathID));
    pathFilter = pathFilter.Or(i => i.Paths.Contains(pathID2));
    ...
    // the exclusions, build them up seprately
    var query = PredicateBuilder.True<SearchResultItem>();
    query = query.And(i => !i.TemplateName.Contains("folder"));
    query = query.And(i => !i["_fullpath"].Contains("/testing"));
    
    // join both parts together
    query = query.And(pathFilter);
