    private static ViewModelA AsViewModelInternal(this IQueryable<CustomType> query, 
                                                  ViewModelA dummy) { ... }
    
    private static ViewModelB AsViewModelInternal(this IQueryable<CustomType> query, 
                                                  ViewModelB dummy) { ... }
    
    public static T AsViewModel<T>(this IQueryable<CustomType> query)
    {
      return (T)query.AsViewModelInternal(default(T));
    }
