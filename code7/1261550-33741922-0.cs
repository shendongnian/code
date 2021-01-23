    public static bool SameAs<T>(this T val, params T[] values) where T : struct
    {
        return values.All(x => x.Equals(val));
    }
    if (4.SameAs(2*2,2+2)) { ... }
