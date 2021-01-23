       public static class GlobalConstants
        {
    #if DEBUG
            public const string Uri = "devUri";
    #endif
    #if TEST
            public const string Uri = "testUri";
    #endif
    #if RELEASE
            public const string Uri = "releaseUri";
    #endif
    
        }
