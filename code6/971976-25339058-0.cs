    public class DoSomethingToDb(ISessionFactory sessionFactory)
    {
      using (ISession session = sessionFactory.OpenSession())
      {
          
          //Do Stuff
          session.Flush();
      }
    }
