    public class IGen<out T> 
        where T : Parent 
    {
        T Variable{ get; }
    }
    public class Gen<T>
        : IGen<T>
        where T : Parent 
    {
        public T Variable {get;set;}
        
        private static Func<T, T, bool> _equal;
        static Gen()
        {
            var left = Expression.Parameter(typeof(T));
            var right = Expression.Parameter(typeof(T));
            var body = Expression.Equal(left, right);
            var lambda = Expression.Lambda<Func<T, T, bool>>(body, left, right);
            _equal = lambda.Compile();
        }
        public static bool operator ==(Gen<T> left, Gen<T> right)
        {
            return _equal(left.Variable, right.Variable);
        }
        public static bool operator ==(Gen<T> left, IGen<T> right)
        {
            return _equal(left.Variable, right.Variable);
        }
        public static bool operator ==(IGen<T> left, Gen<T> right)
        {
            return _equal(left.Variable, right.Variable);
        }
    }
