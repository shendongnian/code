    public static string ToString(this MySqlDateTime mdt, string format)
    {
        return mdt.ToString(format, null);
    }
    public static string ToString(this MySqlDateTime mdt, string format, IFormatProvider provider)
    {
        return mdt.IsValidDateTime 
            ? mdt.GetDateTime().ToString(format, provider) 
            : new DateTime(1, 1, 1).ToString(format, provider).Replace('1', '0');
    }
