    using (ISession session = NHibernateHelper.OpenSession())
    {
        ...
        session.Flush();
    }
