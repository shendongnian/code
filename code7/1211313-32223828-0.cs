    static class Ext {
      public static async Task SurroundWithUIGuard(this Task task, SomeButton button) {
        button.Enabled = false;
        try { await task; }
        finally { button.Enabled = true; }
      }
    }
