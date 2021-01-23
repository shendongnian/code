    private static readonly Dictionary<Type, Expression> Mappings = 
        new Dictionary<Type, Expression>
        {
            { typeof(ViewModelA),
              Helper<ViewModelA>(x => new ViewModelA { Something = x.Something }) },
            { typeof(ViewModelB),
              Helper<ViewModelB>(x => new ViewModelB { SomethingElse = x.SomethingElse }) },
            ...
        }
    // This method just helps avoid casting all over the place.
    // In C# 6 you could use an expression-bodied member - or add a 
    private static Expression<Func<CustomType, T>> Helper<T>
        (Expression<Func<CustomType, T>> expression)
    {
        return expression;
    }
    public static T AsViewModel<T>(this IQueryable<CustomType> query) 
    { 
        Expression rawMapping;
        if (!Mappings.TryGetValue(typeof(T), out rawMapping))
        {
            throw new InvalidOperationException("Or another exception...");
        }
        // This will always be valid if we've set up the dictionary properly
        var mapping = (Expression<Func<CustomType, T>>) rawMapping;
        return view.Select(mapping).FirstOrDefault();
    }
