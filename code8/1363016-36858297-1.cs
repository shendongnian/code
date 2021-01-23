    var predicate = PredicateBuilder.True<User>()
    predicate = BuildIdQuery(predicate, id1, a => a.id1);
    predicate = BuildIdQuery(predicate, id2, a => a.id2);
    foreach(var term in searchTerms)
    {
        predicate = BuildSearchTermQuery(predicate, term);
    }
    var results = db.Users
        .Where(predicate)
        .Skip(...)
        .Take(...);    
