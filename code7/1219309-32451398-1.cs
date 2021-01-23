    public static class MyExtensions
    {
        public static void MySelect<T, TResult>(this IQueryable<T> query, Expression<Func<T, TResult>> projection)
        {
            System.Diagnostics.Debug.WriteLine(projection);
        }
    }
