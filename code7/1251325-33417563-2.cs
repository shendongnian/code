    static string getMemoryStatusString() {
      // Do not forget to collect the garbage (all the generations)
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
        //TODO: You must not do this: disposing instanse you don't own  
        fontFamily.Dispose(); 
      }
    }
    // Test itself
    static void Main(string[] args) {
      // Warming up: let all the libraries (dll) be loaded, 
      // caches fed, prefetch (inf any) done etc.
      for (int i = 0; i < 10; ++i) 
        methodOnTest();
      // Now, let's run the test: just one execution more
      // if you have a leak, s1 and s2 will be different
      // since each run leads to leak of number of bytes
      string s1 = getMemoryStatusString();
      methodOnTest();  
      string s2 = getMemoryStatusString();
      Console.Write(s1 + " -> " + s2);
    }
