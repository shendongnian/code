    var predicate = PredicateBuilder.True<o_order>();
    var oldPredicate = predicate;
    bool case1applied = !string.IsNullOrEmpty(....);
    if (case1applied)
        predicate = predicate.And(s => ........... );
    bool case2applied = !string.IsNullOrEmpty(....);
    if (case2applied)
        predicate = predicate.And(s => ........... );
    if(predicate == oldPredicate) // or the hard way: !case1applied && !case2applied
        ; // no filters applied
    else
        if(case1applied && case2applied) // all filters applied
        else ....
