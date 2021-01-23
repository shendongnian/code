    public void CompareMethod<T>()
    {
        if (typeof(T).IsGenericType && 
            typeof(T).GetGenericTypeDefinition() == typeof(IExample<>)) {
        {
            //execute
        }
    }
