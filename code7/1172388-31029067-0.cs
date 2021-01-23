    public string GetLongest(string str1, string str2)
    {
        return str1.Length > str2.Length ? str1 : str2;
    }
    public string GetShortest(string str1, string str2)
    {
        return str1.Length > str2.Length ? str2 : str1;
    }
    string longestString = GetLongest(string1, string2);
    string shortestString = GetShortest(string1, string2);
