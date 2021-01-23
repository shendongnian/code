    public static class Singleton<T> where T : new()
    {
        public static event EventHandler<SingletonChangedEventArgs> SingletonChangedEvent;
        public static T Instance { get { return instance; } }
        private static T instance = new T();
        public static void SetSingleton(T newInstance)
        {
            T temp = instance;
            instance = newInstance;
            if (SingletonChangedEvent != null)
                SingletonChangedEvent(instance, new SingletonChangedEventArgs { PreviousInstance = temp});
        }
    }
