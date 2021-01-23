    string remove = "con";
    string sep = "?";
    string result = "";
    foreach (string p in postString.Replace("?", "").Split("&"))
    {
        if (p.Split("=")[0] != remove)
        {
            result += sep + p;
            sep = "&";
        }
    }
    return result;
