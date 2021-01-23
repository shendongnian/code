    public static string DB_Replace_Str(string st, string stFrom, string stTo)
    {
        string pattern = string.Format("\\B{0}\\b", stFrom);
        return Regex.Replace(st, pattern, stTo);
    }
