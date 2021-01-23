    public static class ServerName
    {
        #if DEBUG
            const string SERVER = "DebugServer";
        #else
            const string SERVER = "ReleaseServer";
        #endif
        public static string Name => SERVER;
    }
