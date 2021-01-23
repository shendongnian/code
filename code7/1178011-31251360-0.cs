    public static class GenericClass
    {
        // static factory method
        public static GenericClass<T> StaticFactory<T>(T resultData)
        {
            return new GenericClass<T>(resultData);
        }
    }
