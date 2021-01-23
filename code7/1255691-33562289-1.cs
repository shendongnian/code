    public sealed class Singleton
    {
        private Singleton()
        {
          // Use the trick suggested bu @leppie to check for the method
          // if an exception occurs disable that code path
        }
        public static Singleton Instance { get { return Nested.instance; } }
        
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
              // Code here will only ever run if you access the type.
            }
            // Add [DllImport(...)] stuff here
            internal static readonly Singleton instance = new Singleton();
        }
    }
