    // Subquery
    var subquery = DetachedCriteria.For<OptionPrice >()
        .CreateAlias("Increment", "i", JoinType.InnerJoin)
        .Add(Restrictions.Eq("i.IncrementYear", 2015))
        .SetProjection(Projections.Property("Option.ID"));
    // root query, ready for paging, and still filtered as wanted
    ICriteria pagedCriteria = this.Session.CreateCriteria<OptionIdentifier>()
        .Add(Subqueries.PropertyIn("ID", subquery))
        .SetResultTransformer(CriteriaSpecification.DistinctRootEntity);
