     public class FirstPropertyWithTypeSelector<T>
     {
         private readonly IQueryable<T> _source;
         public FirstPropertyWithTypeSelector(IQueryable<T> source)
         {
            _source = source;
         }
         public IQueryable<TResult> OfType<TResult>() 
         {
             // Your clever code in here
         }
     }
     public static IQueryable<TResult> SelectFirstProperty(this IQueryable<T> source)
    {
        return new FirstPropertyWithTypeSelector<T>(source);
    }
