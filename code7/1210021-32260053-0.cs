    var topPredicate = PredicateBuilder.True<LandRecord>();
    topPredicate = topPredicate.And(a=>a.InstrumentType == "DEED");
    topPredicate = topPredicate.And(a=>a.BookType == "OFFICIAL RECORD");
    
    var subPredicate = PredicateBuilder.True<Party>();
    if (!string.IsNullOrWhiteSpace(firstName)
    {
        subPredicate = subPredicate.And(b => b.FirstName == firstName);
    }
    if (!string.IsNullOrWhiteSpace(lastName)
    {
        subPredicate = subPredicate.And(b => b.LastName == lastName);
    }
    // If the subPredicate's body is still just PredicateBuilder.True<Party>(), ignore it.
    if (!(subPredicate.Body is ConstantExpression))
    {
        topPredicate = topPredicate.And(lr => lr.Parties.AsQueryable().Any(subPredicate));
    }
