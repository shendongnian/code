    private static T GetAll<T>() where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
           throw new NotSupportedException(); // You'd want something better here, of course.
        }
            
        long ret = 0; // you could determine the type with reflection, but it might be easier just to use multiple methods, depending on how often you tend to use it.
        foreach(long v in Enum.GetValues(typeof(T)))
        {
            ret |= v;
        }
        return (T)ret;
    }
