    [Flags]
    public enum MyEnum
    {
        Val1 = 1,
        Val2 = 2,
        Val3 = 4,
    }
    public static T OrTogether<T>()
    {
        T ret = default(T);
        foreach (T val in (T[])Enum.GetValues(typeof(T)))
        {
            ret = Or<T>.Do(ret, val);
        }
        return ret;
    }
