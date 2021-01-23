                var subquery =
                    QueryOver.Of<Product>()
                        .Where(_ => _.SomeOtherEntity.Id == someId)
                        .Select(
                            Projections.ProjectionList()
                                .Add(Projections.SqlGroupProjection("MAX(MaxPerGroupProperty)", "SomeGroupByProperty",
                                    new string[] { "MaxPerGroupProperty" }, new IType[] { NHibernate.NHibernateUtil.Int32 })));
                var parentQuery = session.QueryOver<Product>()
                    .WithSubquery.WhereProperty(x => x.StatVal).In(subquery).List();
