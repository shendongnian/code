    using System.Runtime.CompilerServices;
    public static class Helpers
    {
        public static string GetCallerName([CallerMemberName] caller = null)
        {
            return caller;
        }
    }
