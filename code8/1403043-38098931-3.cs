    Results.Add(GetCaller(), result);
    public static string GetCaller([CallerMemberName] string caller = null)
    {
        return caller;
    }
