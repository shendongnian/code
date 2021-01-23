    public static bool IsPalindrome(this string str1, string str2)
    {
        if(string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2)) return false;
        return str1.SequenceEqual(str2.Reverse());
    }
