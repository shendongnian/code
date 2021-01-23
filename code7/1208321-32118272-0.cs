    // First approach
    private static Response GetTestData(int a, string b)
    {
        int c;
        return WaitForAPIReply(() => GetData(a, b, out c));
    }
    // Second approach
    private static Response GetTestData(int a, string b, int c)
    {
        return WaitForAPIReply(() => GetData(a, b, out c));
    }
    // Third approach
    private static Response GetTestData(int a, string b, out int c)
    {
        return WaitForAPIReply(() => GetData(a, b, out c));
    }
