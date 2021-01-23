    private static bool checkForIllegalCrossThreadCalls = Debugger.IsAttached;
    public static bool CheckForIllegalCrossThreadCalls {
        get { return checkForIllegalCrossThreadCalls; }
        set { checkForIllegalCrossThreadCalls = value; }
    }
