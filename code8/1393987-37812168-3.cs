    static class Namespace
    {
        //generic
        static bool Contains<T1, T2>()
        {
            return typeof(T1).Namespace == typeof(T2).Namespace;
        }
        //Non-generic
        static bool Contains(Type type1, Type type2)
        {
            return type1.Namespace == type2.Namespace;
        }
    }
