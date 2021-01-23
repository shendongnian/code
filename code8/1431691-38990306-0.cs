    class Program {
      // This is the entry point of the EXE
      public static void Main() {
    #if DEBUG
      // Start Debug Application
      ...
    #else
      // Shipped to client - Entry point disabled
      return;
    #endif
      }
    }
