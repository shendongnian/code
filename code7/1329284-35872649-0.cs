    using NHibernate.Linq;
    using System.Linq;
    ...
    
    var ids = new [] { 1, 2, 3 };
    var v_groupsQuery = voUnitWork.Session.Query<v_groups>();
    var query = v_groupsQuery
        .Where(v => 
            v_groupsQuery
                .Where(g => ids.Contains(g.ID))
                .Select(g => g.Nr)
                .Distinct()
                .Contains(v.Nr))
        .ToList();
