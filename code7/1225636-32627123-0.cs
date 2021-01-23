    static partial class Debug
    {
        private static readonly object s_ForLock = new Object();
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Assert(bool condition)
        {
            Assert(condition, string.Empty, string.Empty);
        }
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            Assert(condition, message, string.Empty);
        }
     ................................
