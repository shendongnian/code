    var predicate = PredicateBuilder.False<SomeEntity>();
    predicate = predicate.Or (p => p.A == true);
    if(something)
       predicate = predicate.Or (p => p.B == true);
    
    var query = entities.AsExpandable().Where (predicate); //AsExpandable() for EF
