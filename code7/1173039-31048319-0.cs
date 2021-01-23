    var predicate = PredicateBuilder.True<o_order>();
    var oldPredicate = predicate;
    if (!string.IsNullOrEmpty(param.sSearch))
        predicate = predicate.And(s => ........... );  // replace!
    if (!string.IsNullOrEmpty(....))
        predicate = predicate.And(s => ........... );  // replace!
    if(predicate == oldPredicate)   // was it changed?
        ; // no filters applied
    else
        ; // some filters applied
