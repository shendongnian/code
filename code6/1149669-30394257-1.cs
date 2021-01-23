    var subquery = DetachedCriteria.For<Fund>()
        .CreateAlias("FundDetails", "fd", JoinType.LeftOuterJoin)
        .CreateAlias("FundAliases", "fa", JoinType.LeftOuterJoin)
        .Add(
            Restrictions.InsensitiveLike("fd.Symbol", filterValue, MatchMode.Anywhere) ||
            Restrictions.InsensitiveLike("Name", filterValue, MatchMode.Anywhere) ||
            Restrictions.InsensitiveLike("fa.Symbol", filterValue, MatchMode.Anywhere))
        .SetProjection(Projections.Distinct(Projections.Id()));
    
    var funds = session.CreateCriteria<Fund>()
        .Add(Subqueries.PropertyIn(Projections.Id()).In(subquery))
        .SetFetchMode("FundDetails", FetchMode.Eager) // for example
        .OrderBy(Projections.Id())
        .SetFirstResult(0).SetMaxResults(100)
        .SetResultTransformer(Transformers.DistinctRootEntity())
        .List<Fund>();
