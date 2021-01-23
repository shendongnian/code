    public static Action Log(this Delegate action, string log, params object[] args)
    {
        return () =>
        {
            Console.WriteLine(log);
            action.DynamicInvoke(args);
        };
    }
