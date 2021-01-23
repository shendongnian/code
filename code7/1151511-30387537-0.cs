    public class Fruit { }
    class FruitHandlers
    {
        private Dictionary<Type, Action<Fruit>> handlers = new Dictionary<Type, Action<Fruit>>();
        public event Action<Fruit> FruitAdded
        {
            add
            {
                handlers[typeof(Fruit)] += value;
            }
            remove
            {
                handlers[typeof(Fruit)] -= value;
            }
        }
        public FruitHandlers()
        {
            handlers = new Dictionary<Type, Action<Fruit>>();
            handlers.Add(typeof(Fruit), null);
        }
        static IEnumerable<Type> GetInheritanceChain(Type child, Type parent)
        {
            for (Type type = child; type != parent; type = type.BaseType)
            {
                yield return type;
            }
            yield return parent;
        }
        public void RegisterHandler<T>(Action<T> handler) where T : Fruit
        {
            Type type = typeof(T);
            Action<Fruit> wrapper = fruit => handler(fruit as T);
            
            if (handlers.ContainsKey(type))
            {
                handlers[type] += wrapper;
            }
            else
            {
                handlers.Add(type, wrapper);
            }
        }
        private void InvokeFruitAdded(Fruit fruit)
        {
            foreach (var type in GetInheritanceChain(fruit.GetType(), typeof(Fruit)))
            {
                if (handlers.ContainsKey(type) && handlers[type] != null)
                {
                    handlers[type].Invoke(fruit);
                }
            }
        }
    }
