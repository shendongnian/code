    static class Namespace
    {
        public static bool Contains<T>() 
            => typeof (T).Namespace == typeof (Namespace).Namespace;
    }    
