    public static class DynamicAggregator
    {
        public static double AggregateDynamic<T>(this IEnumerable<T> source, string propertyName, string func)
        {
            return GetFunc<T>(propertyName, func)(source);
        }
        static Func<T, double> GetFunc<T>(string propertyName, string func)
        {
            return BuildFunc<T>(propertyName, func);
        }
        static Func<T, double> BuildFunc<T>(string propertyName, string func)
        {
            var source = Expression.Parameter(typeof(IEnumerable<T>), "source");
            var item = Expression.Parameter(typeof(T), "item");
            Expression value = Expression.PropertyOrField(item, propertyName);
            if (value.Type != typeof(double)) value = Expression.Convert(value, typeof(double));
            var selector = Expression.Lambda<Func<T, double>>(value, item);
            var methodCall = Expression.Lambda<Func<IEnumerable<T>, double>>(
                Expression.Call(typeof(Enumerable), func, new Type[] { item.Type }, source, selector),
                source);
            return methodCall.Compile();
        }
    }
