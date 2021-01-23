    public static T TestAndConvert<T>(object o)
    {
        Assert.IsInstanceOfType(o, typeof(T));
        return (T)o;
    }
