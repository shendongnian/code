    class Resolver
    {
        static class ResolverCache<T>
        {
            public static T Resolver { get; set; }
        }
        void AddResolver<T>(T resolver)
        {
            ResolverCache<T>.Resolver = resolver;
        }
        public Resolver()
        {
            Func<int, int> intResolver = o => (int)o * (int)o;
            Func<int, int, int> intResolver2 = (o, p) => (int)o * (int)p;
            Func<string, string> stringResolver = o => (string)o + (string)o;
            AddResolver(intResolver);
            AddResolver(intResolver2);
            AddResolver(stringResolver);
            // and so on; 
        }
        public T Invoke<T>(T t1)
        {
            var resolver = ResolverCache<Func<T, T>>.Resolver ?? (v => { throw new Exception("No resolver registered."); });
            return resolver(t1);
        }
        public T Invoke<T>(T t1, T t2)
        {
            var resolver = ResolverCache<Func<T, T, T>>.Resolver ?? ((v, u) => { throw new Exception("No resolver registered."); });
            return resolver(t1, t2);
        }
    }
