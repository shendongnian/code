    public string GetLongestString(string str1, string str2)
    {
        return str1.Length > str2.Length ? str1 : str2;
    }
    public string GetShortestString(string str1, string str2)
    {
        return str1.Length > str2.Length ? str2 : str1;
    }
    string longestString = GetLongestString(string1, string2);
    string shortestString = GetShortestString(string1, string2);
