    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    String hqlDelete = "delete Entity_A ea where ea.Code = :code";
    int deletedEntities = session.CreateQuery( hqlDelete )
            .SetString( "code", codeToDelete )
            .ExecuteUpdate();
    tx.Commit();
    session.Close();
