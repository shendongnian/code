    class GameObject
    {        
        private readonly Transition transition = new Transition();
        private readonly Dictionary<Type, Component> components = new Dictionary<Type, Component>();        
        public GameObject()
        {
            AddComponent(transition);
        }
        public Transition Transition { get { return transition; } }
        public T GetComponent<T>() where T : Component
        {
            Component component;
            if (components.TryGetValue(typeof (T), out component))
            {
                return (T) component;
            }
            return null;
        }
        public void AddComponent<T>(T component) where T : Component
        {
            Type type = typeof (T);
            if (!components.ContainsKey(type))
            {
                components.Add(type, component);
            }
        }
        public void RemoveComponent<T>() where T : Component
        {                        
            if (typeof(T) != typeof(Transition))
            {
                components.Remove(typeof (T));                
            }
        }
    }
