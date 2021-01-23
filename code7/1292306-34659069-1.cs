    static class NamespaceHelper 
    {
        public static List<Type> FindTypesInSameNamespaceAs(object instance)
        {
            string ns = instance.GetType().Namespace;
            Type instanceType = instance.GetType();
            List<Type> results = instance.GetType().Assembly.GetTypes().Where(tt => tt.Namespace == ns &&
                                                                              tt != instanceType).ToList();
            return results;
        }
        public static List<T> InstantiateTypesInSameNamespaceAs<T>(object instance)
        {
            List<T> instances = new List<T>();
            foreach (Type t in FindTypesInSameNamespaceAs(instance))
            {
                if (t.IsSubclassOf(typeof(T)))
                {
                    T i =(T) Activator.CreateInstance(t);
                    instances.Add(i);
                }
            }
            return instances;
        }
    }
