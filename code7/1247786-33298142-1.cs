    var pairs = new List<Pair>
    {
        Pair.Create(1000, "Car"),
        Pair.Create(2000, "Truck"),
    };
    
    List<Mapping> result =
        pairs
        .Select(pair =>
            context.Mappings.Where(
                x => x.ReferenceId == pair.Id
                && x.ReferenceType == pair.Type))
        .Aggregate(Queryable.Union)
        .ToList();
