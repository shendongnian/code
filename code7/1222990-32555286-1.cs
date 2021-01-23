    interface IDomain{
    }
    class ExpiredInvoices: IDomain{
    }
    
    class ActiveInvoices: IDomain{
    }
    interface IRepository{
    }
    
    class Repsoitory: IRepository  {
          public static IList<T> Get<T>() where T: IDomain //default one
          {
              using (ISession session = OpenEngineSession())
              {
                  return session.Query<T>().ToList();
              }
          }
          public static IList<T> Get<T>(Expression<Func<T, bool>> expression) where T: IDomain // overloaded get with linq predicate
          {
              using (ISession session = OpenEngineSession())
              {
                  return session.Query<T>().Where(expression).ToList();
              }
          }
    }
