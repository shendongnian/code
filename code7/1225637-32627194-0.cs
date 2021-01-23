    public static class Debug
    {
        public static bool IsInDebugMode { get; set; }
    
        public static void Print(string message)
        {
            if (IsInDebugMode) Console.Write(message);
        }
    }
