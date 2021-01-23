    internal static class LocalExtensions
    {
       internal static IgnoreCast ic = new IgnoreCast();
       internal static IQueryable<T> FilterEnabled<T>(this IQueryable<T> query) where T: class
       {
          Expression<Func<T,bool>> expr = e => ((IEnabledEntity)e).IsEnabled;
          expr = (Expression<Func<T,bool>>)ic.Visit(e);
          return query.Where(expr);
       }
    }
