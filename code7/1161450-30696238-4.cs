    class BaseData
    {
        private static List<IHaveData> collection;
        public static IEnumerable<IHaveData> getCollection()
        {
            if (collection == null)
            {
                var types = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(type =>
                        type.IsClass &&
                        !type.IsAbstract && 
                        type.GetInterfaces().Any(i => i == typeof(IHaveData)));
                //All implementation must have the same constructor signature. In this case, a parameterless constructor.
                collection = new List<IHaveData>(types.Select(x => (IHaveData)Activator.CreateInstance(x)));
            }
            return collection;
        }
    }
