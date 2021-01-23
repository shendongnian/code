    class Resolver
    {
        readonly IDictionary<Type, object> _unaryFuncs = new Dictionary<Type, object>();
        readonly IDictionary<Type, object> _binaryFuncs = new Dictionary<Type, object>();
        public Resolver()
        {
            _unaryFuncs.Add(typeof(int),  new Func<int, int>(o => o * o));
            _unaryFuncs.Add(typeof(string), new Func<string, string(o => o + o));
            _binaryFuncs.Add(typeof(int), new Func<int, int, int>((x, y) => x + y));
            // and so on; 
        }
        public T Invoke<T>(T t1)
        {
            var f = _unaryFuncs[typeof(T)] as Func<T, T>;
            return f(t1);
        }
        public T Invoke<T>(T t1, T t2)
        {
            var f = _binaryFuncs[typeof(T)] as Func<T, T, T>;
            return f(t1, t2);
        }
    }
