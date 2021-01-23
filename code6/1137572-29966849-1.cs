    public static long? TryGetInt64(this string item)
    {
        long l;
        bool success = System.Int64.TryParse(item, out l);
        return success ? (long?)l : (long?)null;
    }
