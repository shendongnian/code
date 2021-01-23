    using System.Runtime.CompilerServices;
    public static class Helpers
    {
        public static string GetCallerName([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
