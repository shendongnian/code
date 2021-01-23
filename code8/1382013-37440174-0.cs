    var predicate = PredicateBuilder.False<Table>();
    
    foreach (string t in myList)
    {
        predicate = predicate.Or(c =>c.ID == t.Item1 && c.AnotherValue == t.Item2));
    }
    db.Table.AsExpandable().Where(predicate);
