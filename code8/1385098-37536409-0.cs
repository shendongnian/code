    static class App {
    
      public static string AppDir => AppDomain.CurrentDomain.BaseDirectory;
    
      [STAThread]
      static void Main() {
    
        DbEng.PutIdbVal("x", "Y");  // Method under test - Works here
    
      }
    }
