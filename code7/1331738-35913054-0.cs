    private static MyGenericClass<T2> GetMyGenericClassOrNull<T, T2>(T value)
    {
        if (value != null)
        {
            var underlyingType = Nullable.GetUnderlyingType(typeof(T));
            if (underlyingType == null)
            {
                return new MyGenericClass<T2>((T2)(object)value);
            }
            else
            {
                Type t = typeof(MyGenericClass<>).MakeGenericType(underlyingType);
                object o = Activator.CreateInstance(t, value);
                return (MyGenericClass<T2>)o;
            }
        }
        return null;
    }
