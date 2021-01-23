    public static bool AreAssertionsEnabled = false;
    static MyClassName() { MaybeSetEnabled(); /* call deleted in RELEASE builds */ }
    [Conditional("DEBUG")]
    static void MaybeSetEnabled()
    {
        AreAssertionsEnabled = true;
    }
