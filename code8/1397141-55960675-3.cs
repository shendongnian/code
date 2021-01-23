    public interface IKeyedFactory<TKey, out TValue> : IDictionary<TKey, Type>
    {
        TValue Get(TKey match);
    }
    public class KeyedFactory<TKey, TValue> : Dictionary<TKey, Type>, IKeyedFactory<TKey, TValue>
    {
        private readonly Container _container;
        private readonly bool _autoRegister;
        private readonly Lifestyle _lifestyle;
         public KeyedFactory(Container container) : this(container, false, null)
        {
        }
         public KeyedFactory(Container container, Lifestyle lifestyle) : this(container, true, lifestyle)
        {
        }
         private KeyedFactory(Container container, bool autoRegister, Lifestyle lifestyle)
        {
            _container = container;
            _autoRegister = autoRegister;
            _lifestyle = lifestyle;
        }
         public new void Add(TKey key, Type value)
        {
            if (_autoRegister)
            {
                _container.Register(value, value, _lifestyle);
            }
             base.Add(key, value);
        }
         public TValue Get(TKey source) =>
            (TValue)_container.GetInstance(this[source]);
    }
    public static class ContainerExtensions
    {
        public static TValue GetInstance<TFactory, TKey, TValue>(this Container container, TKey match) where TFactory : class, IKeyedFactory<TKey, TValue>
        {
            var factory = (IKeyedFactory<TKey, TValue>)container.GetInstance<TFactory>();
            return factory.Get(match);
        }
    }
