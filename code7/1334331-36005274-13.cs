        public interface IDbContextFactory
        {
            /// <summary>
            /// Creates a new context.
            /// </summary>
            /// <returns></returns>
            IDbContext GenerateContext();
    
            /// <summary>
            /// Returns the previously created context.
            /// </summary>
            /// <returns></returns>
            IDbContext GetCurrentContext();
        }
    
        public class DbContextFactory : IDbContextFactory
        {
            private readonly IInstanceFactory _instanceFactory;
            private IDbContext _context;
    
            public DbContextFactory(IInstanceFactory instanceFactory)
            {
                _instanceFactory = instanceFactory;
            }
    
            public IDbContext GenerateContext()
            {
                _context = _instanceFactory.CreateInstance<IDbContext>();
                return _context;
            }
    
            public IDbContext GetCurrentContext()
            {
                if (_context == null)
                    _context = GenerateContext();
                return _context;
            }
        }
    
        /// <summary>
        /// Creates an instance of a specific model.
        /// </summary>
        public interface IInstanceFactory
        {
            /// <summary>
            /// Creates an instance of type T.
            /// </summary>
            T CreateInstance<T>();
        }
    
        /// <summary>
        /// Creates an instance based on the model defined by Unity.
        /// </summary>
        public class InstanceFactory : IInstanceFactory
        {
            private readonly IDictionary<Type, Func<object>> _funcs;
    
            public InstanceFactory(IEnumerable<Func<object>> createFunc)
            {
                // To remove the dependency to Unity we will receive a list of funcs that will create the instance.
    
                _funcs = new Dictionary<Type, Func<object>>();
    
                foreach (var func in createFunc)
                {
                    var type = func.Method.ReturnType;
                    _funcs.Add(type, func);
                }
            }
    
            /// <summary>
            /// Creates an instance of T.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public T CreateInstance<T>()
            {
                var func = _funcs[typeof(T)];
                return (T) func();
            }
        }
