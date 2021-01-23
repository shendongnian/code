    public static string trimString(string str, int max = 16)
    {
        if (str.Length <= max)
        {
            return str;
        }   
        return str.Substring(0, max / 2) + "..." + str.Substring(str.Length - max / 2, max / 2);
    }
