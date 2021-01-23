    public static TResult Run<TService, TResult>(this IDataService<TService> @this, 
                                                 Func<TService, TResult> func)
    {
      if (typeof(IDisposable).IsAssignableFrom(typeof(TService)))
      {
        using (var service = (@this.GetInstance() as IDisposable))
        {
          return func(@this);
        }
      }
      else
      {
        return func(@this.GetInstance());
      }
    }
