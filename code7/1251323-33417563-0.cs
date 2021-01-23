    static string getMemoryStatusString() {
      // Collect the garbage
      GC.Collect(2);
      GC.WaitForFullGCComplete();
      using (Process p = Process.GetCurrentProcess()) {
        return "(p: " + p.PrivateMemorySize64 + ", v:" + p.VirtualMemorySize64 + ")";
      }
    }
    // Suspected method
    static void methodOnTest() {
      foreach (FontFamily fontFamily in FontFamily.Families) {
        //Console.Write(fontFamily.Name + " " + getMemoryStatusString() + " -> ");
        fontFamily.IsStyleAvailable(FontStyle.Regular);
        fontFamily.Dispose();
      }
    }
    // Test itself
    static void Main(string[] args) {
      // Warming up: let all the library (dll) be loaded, caches fed, prefetch (inf any) done etc.
      for (int i = 0; i < 10; ++i) {
        methodOnTest();
      }
      // Now, let's test: one execution more
      // if you have a leak s1 and s2 will be different
      string s1 = getMemoryStatusString();
      methodOnTest();  
      string s2 = getMemoryStatusString();
      Console.Write(s1 + " -> " + s2);
    }
