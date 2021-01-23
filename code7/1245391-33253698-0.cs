    public interface IDecoratorLayerQuery<TDecorated>
    {
      IDecoratorLayerQuery<TDecorated> Where (Expression<Func<TDecorated, bool>> predicate);
      // etc.      
    }
    public class DecoratorLayerQuery<TDecorated, TUnderlying> : IDecoratorLayerQuery<TDecorated>
    {
      private IQueryable<TUnderlying> _underlyingQuery;
      
      public DecoratorLayerQuery(IQueryable<TUnderlying> underlyingQuery)
      {
        _underlyingQuery = underlyingQuery;
      }
      
      public IDecoratorLayerQuery<TDecorated> Where (Expression<Func<TDecorated, bool>> predicate)
      {
        var newUnderlyingQuery = _underlyingQuery.Where(TranslateToUnderlying(predicate));
        return new DecoratorLayerQuery<TDecorated, TUnderlying> (newUnderlyingQuery);
      }
      
      private Expression<Func<TUnderlying, bool>> TranslateToUnderlying(Expression<Func<TDecorated, bool>> predicate)
      {
        var decoratedParameter = predicate.Parameters.Single();
        var underlyingParameter = Expression.Parameter(typeof(TUnderlying), decoratedParameter.Name + "_underlying");
        
        var bodyWithUnderlyingParameter = ReplaceDecoratedItem (decoratedParameter, underlyingParameter, predicate.Body);
        
        return Expression.Lambda<Func<TUnderlying, bool>> (bodyWithUnderlyingParameter, underlyingParameter);
      }
      
      private Expression ReplaceDecoratedItem(Expression decorated, Expression underlying, Expression body)
      {
        // Magic happens here: Implement an expression visitor that iterates over body and replaces all occurrences with _corresponding_ occurrences of _underlying_.
        // This will probably involve translating member expressions as well. E.g., if decorated is of type IPerson, decorated.FullName must instead become 
        // the Expression equivalent of 'underlying.FirstName + " " + underlying.FullName'.
      }
      public List<TDecorated> ToList() // And AsEnumerable, AsQueryable, etc.
      {
        var projection = /* construct Expression that transforms TUnderlying to TDecorated here */;
        return _underlyingQuery.Select(projection).ToList();
      }
    }
    public static class DecoratorLayerQueryFactory
    {
      public static IDecoratorLayerQuery<TDecorated> CreateQuery<TDecorated>()
      {
        var underlyingType = /* calculate underlying type for TDecorated here */;
        var queryType = typeof (DecoratorLayerQuery<,>).MakeGenericType (typeof (TDecorated), underlyingType);
        var initialSource = DbContext.Set(underlyingType);
        return (IDecoratorLayerQuery<TDecorated>) Activator.CreateInstance (queryType, initialSource);
      }
    }
    var exampleQuery =
        from p in DecoratorLayerQueryFactory.CreateQuery<IPerson>
        where p.FullName == "John Doe"
        select p.FirstName;
