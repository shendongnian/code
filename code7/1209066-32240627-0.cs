    ISessionFactory sessionFactory = //get the factory
    using (session = sessionFactory.OpenSession())
    using (tx = session.BeginTransaction())
    {
      var query = session.CreateSQLQuery("exec UpdateBook @BookId=:bookid");
      query.SetInt32("bookid", bookId);
      query.ExecuteUpdate();
      tx.Commit();
    }
