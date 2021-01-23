    public static bool NumericalEquals(object x, ulong y)
    {
        if (x.GetHashCode() != y.GetHashCode()) return false;
        ...
    }
