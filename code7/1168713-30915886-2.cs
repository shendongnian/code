    var subquery =
        QueryOver.Of<SomeEntity>()
            .Where(_ => _.SomeOtherEntity.Id == someId)
            .Select(
                Projections.ProjectionList()
                    .Add(Projections.SqlGroupProjection("max(MaxPerGroupProperty) as maxAlias", "SomeGroupByProperty",
                        new string[] { "maxAlias" }, new IType[] { NHibernate.NHibernateUtil.Int32 })));
    var parentQuery = session.QueryOver<SomeEntity2>()
        .WithSubquery.WhereProperty(x => x.MaxPerGroupPropertyReference).In(subquery).List();
