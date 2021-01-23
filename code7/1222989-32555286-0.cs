    class ExpiredInvoices: IDomain{
    }
    
    class ActiveInvoices: IDomain{
    }
    interface IRepository<T> where T: IDomain{
    }
    
    class Repsoitory<T>: IRepository<T> where T: IDomain {
          public static IEnumerable<T> Get<T>() //default one
          {
              using (ISession session = OpenEngineSession())
              {
                  return session.Query<T>();
              }
          }
          public static IEnumerable<T> Get<T>(Expression<Func<T, bool>> expression) // overloaded get with linq predicate
          {
              using (ISession session = OpenEngineSession())
              {
                  return session.Query<T>().Where(expression);
              }
          }
    }
