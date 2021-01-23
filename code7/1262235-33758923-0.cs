    public static String NewLine {
        get {
            Contract.Ensures(Contract.Result() != null);
    #if !PLATFORM_UNIX
            return "\r\n";
    #else
            return "\n";
    #endif // !PLATFORM_UNIX
        }
    }
