    namespace System
    {
        public static class ReflectionExtensions
        {
            public static T GetAttribute<T>(this object classInstance) where T : class
            {
                return ReflectionExtensions.GetAttribute<T>(classInstance, true);
            }
            public static T GetAttribute<T>(this object classInstance, bool includeInheritedAttributes) where T : class
            {
                if (classInstance == null)
                    return null;
    
                Type t = classInstance.GetType();
                object attr = t.GetCustomAttributes(includeInheritedAttributes).Where(a => a.GetType() == typeof(T)).FirstOrDefault();
                return attr as T;
            }
        }
    }
