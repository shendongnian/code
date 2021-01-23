    public string Rewrite(string value)
    {
        string[] values = value.Split('+');
        string requestUrl = values[0];
        string cookieStr = "";
        if (values.Length > 1)
        {
            cookieStr = values[1];
        }
        ...
