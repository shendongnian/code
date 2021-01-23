    public sealed class TypeSwitch<T>
    {
        private Dictionary<Type, Action<T>> _dict; // no longer dynamic
        public TypeSwitch()
        {
            _dict = new Dictionary<Type, Action<T>>();  // no longer dynamic
        }
        public TypeSwitch<T> Add<K>(Action<K> action) where K : T
        {
            _dict.Add(typeof (K), o => action((K) o)); // outer lambda casts the value before calling the inner lambda
            return this;
        }
        public void Execute(T item)
        {
            var type = item.GetType();
            var action = _dict[type];
            action(item);
        }
    }
