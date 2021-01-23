    using NHibernate.Linq;
    ...
    var collection = new List<Item>();
    
    var list = _session
        .Query<MyDbTable>()
        .Where(x => collection.Any(y => y.Id1 == x.Id1 && y.Id2 == x.Id2))
        .ToList();
