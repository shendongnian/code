    public DateTime TryParseOrDefault(string str, DateTime def)
    {
        DateTime ret;
        if (DateTime.TryParse(str))
            return ret;
        else
            return def;
    {
