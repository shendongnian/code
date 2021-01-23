    public sealed class TypeSwitch<T>
    {
        private readonly Dictionary<Type, Action<T>> _dict;
        public TypeSwitch()
        {
            _dict = new Dictionary<Type, Action<T>>();
        } 
         
        public TypeSwitch<T> Add<TChild>(Action<TChild> action) where TChild : T
        {
            _dict.Add(typeof (TChild), o => action((TChild) o));
            return this;
        }
        public void Execute(T item)
        {
            var type = item.GetType();
            foreach (var kvp in _dict)
            {
                if (type == kvp.Key || kvp.Key.IsAssignableFrom(type))
                {
                    kvp.Value(item);
                    return;
                }
            }
            throw new KeyNotFoundException($"{type} or its baseclass not located in typeswitch.");
        }
    }
