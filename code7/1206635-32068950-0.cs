    public static char[] nums = "0123456789".ToCharArray();
    public static int Compare(string x, string y)
    {
        if (x.LastIndexOfAny(nums) > y.LastIndexOfAny(nums))
        {
            return 1;
        }
        if (x.LastIndexOfAny(nums) == y.LastIndexOfAny(nums))
        {
            return x.CompareTo(y);
        }
        return -1;
    }
