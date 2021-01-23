    public static class JsonExtensions
    {
        public static T DefaultCreate<T>(this JsonSerializer serializer, Type objectType, object existingValue)
        {
            if (serializer == null)
                throw new ArgumentNullException();
            if (existingValue is T)
                return (T)existingValue;
            return (T)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
        }
        public static void PopulateObject(this JToken obj, object target, JsonSerializer serializer)
        {
            if (target == null)
                throw new NullReferenceException();
            if (obj == null)
                return;
            using (var reader = obj.CreateReader())
                serializer.Populate(reader, target);
        }
    }
    public static class TypeExtensions
    {
        /// <summary>
        /// Return all interfaces implemented by the incoming type as well as the type itself if it is an interface.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type> GetCollectItemTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
        }
    }
    public static class ListExtensions
    {
        public static bool RemoveLast<T>(this IList<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException();
            var comparer = EqualityComparer<T>.Default;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (comparer.Equals(list[i], item))
                {
                    list.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
