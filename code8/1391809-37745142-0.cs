    public static class EFextention
    {
        public static IQueryable<T> CustomWhere<T, P>(this IQueryable<T> self, Func<T, P> selector, P value)
        {
            return self.Where(x => selector(x).Equals(value));
        }
    }
