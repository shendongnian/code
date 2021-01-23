    var persons = session.QueryOver<Person>()
                    .Where(Restrictions.Disjunction()
                        .Add(Subqueries.WhereProperty<Person>(x => x.Department.Id).In(QueryOver.Of<Department>().WhereRestrictionOn(x => x.Value).IsInsensitiveLike("somedep", MatchMode.Anywhere).Select(x => x.Id)))
                        .Add<Person>(x => x.LastName.IsInsensitiveLike("somedep", MatchMode.Anywhere)))
                    .Where(Restrictions.Disjunction()
                        .Add(Subqueries.WhereProperty<Person>(x => x.Department.Id).In(QueryOver.Of<Department>().WhereRestrictionOn(x => x.Value).IsInsensitiveLike("myname", MatchMode.Anywhere).Select(x => x.Id)))
                        .Add<Person>(x => x.LastName.IsInsensitiveLike("myname", MatchMode.Anywhere))))
                    .List();
