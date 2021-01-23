    public interface IKey
    {
    }
    public interface IKeyed<out T>
    {
        T this[IKey key] { get; }
    }
    public class Keyed<T> : IKeyed<T>
    {
        private ConcurrentDictionary<IKey, T> _dict = new ConcurrentDictionary<IKey,T>();
        T IKeyed<T>.this[IKey key]
        {
            get 
            {
                return _dict.GetOrAdd(key, k => IoC.Resolve<T>(new TypedParameter(key.GetType(), key)));
            }
        }
    }
