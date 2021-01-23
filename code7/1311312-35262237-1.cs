    public static void CastTo<T, TResult>(this T arg, out TResult var)
    {
        TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));
        bool? converter = typeConverter?.CanConvertTo(typeof(TResult));
        if (converter != null && converter == true)
            var = (TResult)typeConverter.ConvertTo(arg, typeof(TResult));
        else
            var = default(TResult);
    }
