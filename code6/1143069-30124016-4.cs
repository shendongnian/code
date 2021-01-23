    public static bool operator== (DateRange x, DateRange y)
    {
        if (Object.ReferenceEquals(x, y))
            return true;
        if (((object)x == null) || ((object)y == null))
            return false;
        return x.Equals(y);
    }
    public static bool operator !=(DateRange x, DateRange y)
    {
        return !(x == y);
    }
