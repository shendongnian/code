     public class FirstPropertyWithTypeSelector<T>
     {
         private readonly IQueryable<T> _source;
         public FirstPropertyWithTypeSelector(IQueryable<T> source)
         {
            _source = source;
         }
         public IQueryable<TResult> OfType<TResult>() 
         {
             // Get the first property which has the TResult type
              var propertyName = typeof(T).GetProperties()
                 .Where(x => x.PropertyType == typeof(TResult))
                 .Select(x => x.Name)
                 .FirstOrDefault();
             var parameter = Expression.Parameter(typeof(T));
             var body = Expression.Convert(Expression.PropertyOrField(parameter, propertyName), typeof(TResult));
              var expression = Expression.Lambda<Func<T, TResult>>(body, parameter);
             return _source.Select(expression);
         }
     }
     public static FirstPropertyWithTypeSelector<T> SelectFirstProperty(this IQueryable<T> source)
     {
        return new FirstPropertyWithTypeSelector<T>(source);
     }
