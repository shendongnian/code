    public static class Combine<T>
    {
        public static class With<U>
        {
            public static class And<V>
            {
                public static CombinedType<T, U, V> Create
                {
                    get
                    {
                        return new CombinedType<T, U, V>();
                    }
                }
            }
        }
    }
    class CombinedType<T, U, V> { }
    class TypeA { }
    class TypeB { }
    class TypeB { }
    // client call
    var type = Combine<TypeA>.With<TypeB>.And<TypeC>.Create;
