    public static void SomeMethod<T>(IEnumerable<T> SomeParam) where T:SomeBase
    {
        Type type = typeof(T);
        if(type.IsAbstract)
        {
            throw new Exception(string.Format("Cannot use SomeMethod with type {0} because it is abstract.", type.FullName)); 
        }
        // Do the actual work
    }
