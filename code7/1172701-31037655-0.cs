    public static readonly string Thing = RetrySpecialCall();
    private static string RetrySpecialCall()
    {
        while (true)
        {
            try
            {
                return SomeSpecialCallThatRarelyFails();
            }
            catch (Exception) {}
        }
    }
