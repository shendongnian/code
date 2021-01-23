    public static bool operator !=(Portfolio a, Portfolio b)
    {
        if (object.ReferenceEquals(a, null))
        {
            return !object.ReferenceEquals(b, null);
        }
        return !a.Equals(b);
    }
