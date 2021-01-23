    public static class ContainerExtensions
    {
        public static object TryResolve(this Container container, Type type)
        {
            var mi = typeof(Container).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .First(x => x.Name == "TryResolve" &&
                       x.GetGenericArguments().Length == 1 &&
                       x.GetParameters().Length == 0);
            var genericMi = mi.MakeGenericMethod(type);
            var instance = genericMi.Invoke(container, new object[0]);
            return instance;
        }
    }
