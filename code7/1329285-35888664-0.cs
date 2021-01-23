    var subquery = QueryOver.Of<v_groups>()
        .WhereRestrictionOn(u => u.ID).IsIn(new[] { 1, 2, 3 })
        .Select(u => u.Nr);
    var query = voUnitWork.Session
          .QueryOver<v_groups>()
          .WithSubquery.WhereProperty(g => g.Nr).In(subquery)
          .OrderBy(c => c.Nr).Asc
          .List<v_groups>();
