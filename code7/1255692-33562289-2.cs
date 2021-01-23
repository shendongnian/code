    public sealed class Singleton
    {
      [DllImport("kernel32", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
      private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
      [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
      private static extern IntPtr GetModuleHandle(string lpModuleName);
      public bool IsQueryFullProcessImageNameSupported { get; private set; }
      public string QueryFullProcessImageName(IntrPtr handle)
      { 
        if (!IsQueryFullProcessImageNameSupported) {
          throw new Exception("Does not compute!");
        }
        int capacity = 1024;
        var sb = new StringBuilder(capacity);
        Nested.QueryFullProcessImageName(handle, 0, sb, ref capacity);
        return sb.ToString(0, capacity);
      }
      private Singleton()
      {
        // You can use the trick suggested by @leppie to check for the method
        // or do it like this. However you need to ensure that the module 
        // is loaded for GetModuleHandle to work, otherwise see LoadLibrary
        IntPtr m = GetModuleHandle("kernel32.dll");
        if (GetProcAddress(m, "QueryFullProcessImageNameW") != IntrPtr.Zero) 
        {
          IsQueryFullProcessImageNameSupported = true;
        }
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
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool QueryFullProcessImageName([In]IntPtr hProcess, [In]int dwFlags, [Out]StringBuilder lpExeName, ref int lpdwSize);
        public static readonly Singleton instance = new Singleton();
      }
    }
