    public static void SomeMethod<T>(IEnumerable<T> SomeParam) where T:SomeBase
    {
        Type type = typeof(T);
        if(type.IsAbstract)
        {
            SomeMethodAbstract<T>(SomeParam);
        }
        else
        {
            SomeMethodNonAbstract<T>(SomeParam);
        }
    }
