    public class MyClassInstanceHolder
    {
        private static Dictionary<Type, object> Instances { get; } = new Dictionary<Type, object>();
        public static List<T> GetNewOrExistent<T>()
        {
            var type = typeof(MyClass<T>);
            if (Instances.ContainsKey(type))
                return (List<T>)Instances[type];
            Instances.Add(type, MyClass<T>.Values);
            return MyClass<T>.Values;
        }
        public static IEnumerable<object> GetAllInstances() => Instances.Select(i => i.Value);
    }
