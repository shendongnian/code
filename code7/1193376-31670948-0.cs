    private bool IsBalancedRec(string input, int numOpen)
    {
        if (string.IsNullOrEmpty(input))
            return numOpen == 0;
        /* recursive calls */
    }
    public bool IsBalanced(string input)
    {
        return IsBalancedRec(input, 0);
    }
