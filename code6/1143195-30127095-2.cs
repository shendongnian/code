    container.ExpressionBuilt += (s, e) =>
    {
        MethodInfo monitorMethod = 
            this.GetType().GetMethod("Monitor").MakeGenericMethod(e.RegisteredServiceType);
        Delegate producer = Expression.Lambda(
            typeof(Func<>).MakeGenericType(e.RegisteredServiceType), e.Expression)
            .Compile();
        e.Expression = Expression.Call(monitorMethod, Expression.Constant(producer));
    };
    // Method somewhere else in the same class
    public static T Monitor<T>(Func<T> producer) {
        var watch = Stopwatch.StartNew();
        try {
            T instance = producer();
            return instance;
        } finally {
            watch.Stop();
            if (watch.ElapsedMilliseconds > 50) { ... }
        }
    }
