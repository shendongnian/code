                var subquery =
                    QueryOver.Of<SomeEntity>()
                        .Where(_ => _.SomeOtherEntity.Id == someId)
                        .Select(
                            Projections.ProjectionList()
                                .Add(Projections.SqlGroupProjection("MAX(MaxPerGroupProperty)", "SomeGroupByProperty",
                                    new string[] { "MaxPerGroupProperty" }, new IType[] { NHibernate.NHibernateUtil.Int32 })));
                var parentQuery = session.QueryOver<SomeEntity>()
                    .WithSubquery.WhereProperty(x => x.MaxPerGroupProperty).In(subquery).List();
