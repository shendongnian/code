    public static bool IsPalindrome(this string str1)
    {
        if(string.IsNullOrWhiteSpace(str1)) return false;
        return str1.SequenceEqual(str1.Reverse());
    }
