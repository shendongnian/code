    public class MyGenericClass
    {
    }
    public class MyGenericClass<T> : MyGenericClass
    {
        public MyGenericClass(T value)
        {
        }
    }
    public static MyGenericClass GetMyGenericClassOrNull<T>(T? value) where T : struct
    {
        if (value != null)
        {
            return new MyGenericClass<T>(value.Value);
        }
        return null;
    }
    public static MyGenericClass GetMyGenericClassOrNull<T>(T value)
    {
        if (value != null)
        {
            return new MyGenericClass<T>(value);
        }
        return null;
    }
