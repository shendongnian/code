    public DateTime TryParseOrDefault(string str, DateTime def)
    {
        DateTime ret;
        if (DateTime.TryParse(str, out ret))
            return ret;
        else
            return def;
    {
