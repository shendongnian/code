    public class EqualityComparer<TEntity, TProperty>: IEqualityComparer<TEntity>
    {
        private readonly Func<TEntity, TProperty> _property;
        public EqualityComparer(Func<TEntity, TProperty> property)
        {
            _property = property;
        }
        public bool Equals(TEntity x, TEntity y)
        {
            return _property(x).Equals(_property.Invoke(y));
        }
        public int GetHashCode(TEntity obj)
        {
            return _property(obj).GetHashCode();
        }
    }
        
    public static class Extensions
    {
        public static IEnumerable<T> DistinctByProperty<T, TProp>(this IEnumerable<T> source, Func<T, TProp> propertyFunc)
        {
            return source.Distinct(new EqualityComparer<T, TProp>(propertyFunc));
        }
    }
