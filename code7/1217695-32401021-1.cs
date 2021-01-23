    public static int CheckSum(string s)
    {
        int sum = 0;
        foreach (char c in s)
        {
            sum = (sum + c)%10;
        }
        return sum;
    }
