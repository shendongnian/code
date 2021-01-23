    private static bool IsPalindrome(int n)
    {
        string ns = n.ToString(CultureInfo.InvariantCulture);
        var reversed = string.Join("", ns.Reverse());
        return (ns == reversed);
    }
    private static int FindTheNextSmallestPalindrome(int x)
    {
       for (int i = x; i < 2147483647; i++)
       {
           if (IsPalindrome(i))
           {
               return i;
           }
       }
       throw new Exception("Number must be less than 2147483647");
    }
