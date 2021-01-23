    public sealed class Singleton
    {
        private Singleton()
        {
          // Check for DLL functions here
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
