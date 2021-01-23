    public static class UnityExtenstions
    {
        public static bool IsRegisteredAdvanced<T>(this IUnityContainer unityContainer)
        {
            return IsRegisteredAdvanced(unityContainer, typeof(T));
        }
        public static bool IsRegisteredAdvanced(this IUnityContainer unityContainer, Type type)
        {
            var result = unityContainer.IsRegistered(type);
            if (result == false)
            {
                var genericTypeDefinition = GetGenericTypeDefinition(type);
                if (genericTypeDefinition != null)
                {
                    result = unityContainer.IsRegistered(genericTypeDefinition);
                }
            }
            return result;
        }
    
        private static Type GetGenericTypeDefinition(Type type)
        {
            if (type == null) return null;
            var typeInfo = type.GetTypeInfo();
            return (typeInfo.IsGenericType == true)
                && (typeInfo.IsGenericTypeDefinition == false)
                 ? type.GetGenericTypeDefinition()
                 : null;
        }
    }
