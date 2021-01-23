    return HibernateTemplate.Execute(session => (from r in session.Query<Job>()
                                                 group r by r.CustomerName.ToLower()
                                                 into g
                                                 let c = g.Min(l => l.CustomerName)
                                                 orderby c
                                                 select c)).ToList();
