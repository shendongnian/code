    public static class EnumerableTypeExtensions
    {
        public static IEnumerable<Type> WhichImplementsInterface<T>
            (this IEnumerable<Type> types)
        {
            return types.WhichImplementsInterface(typeof (T));
        }
        public static IEnumerable<Type> WhichImplementsInterface
            (this IEnumerable<Type> types, Type interfaceType)
        {
            return types.WhichImplementsInterface(interfaceType.Name);
        }
        public static IEnumerable<Type> WhichImplementsInterface
            (this IEnumerable<Type> types, string interfaceTypeName)
        {
            return types.Where(t => t.GetInterface(interfaceTypeName) != null);
        }
    }
