    public static int NumberOfProperties<T>()
    {
        Type type = typeof(T);
        return type.GetProperties().Count();
    }
