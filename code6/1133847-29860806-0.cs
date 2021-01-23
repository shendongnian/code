    using (var statelessSession = sessionFactory.OpenStatelessSession())
    using (var transaction = statelessSession.BeginTransaction())
    {
        foreach (var item in andamentoList)
        {
            statelessSession.Insert(item);
        } 
        transaction.Commit();
    }
