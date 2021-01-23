    var criteria1 = DetachedCriteria.For<Server>()
                        .Add(Restrictions.Eq("ServerID", s.ServerID))
                        .SetFetchMode("Adapters", FetchMode.Eager)
                        .CreateCriteria("Adapters", JoinType.LeftOuterJoin);
    
    var criteria2 = DetachedCriteria.For<Server>()
                        .Add(Restrictions.Eq("ServerID", s.ServerID))
                        .SetFetchMode("Configurations", FetchMode.Eager)
                        .CreateCriteria("Configurations", JoinType.LeftOuterJoin);
    
    var result = Session.CreateMultiCriteria()
                        .Add(criteria1)
                        .Add(criteria2)
                        .List();
                        
    IList list = (IList)result[0];
    var server = list[0] as Server;      
