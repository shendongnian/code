    public static class MyFactory<T>
    {
        private static Lazy<T> _instance = new Lazy<T>(CreateUsingReflection);
        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static T CreateUsingReflection()
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            ConstructorInfo ctor = typeof(T).GetConstructor(flags, null, Type.EmptyTypes, null);
            return (T)ctor.Invoke(null);
        }
    }
