     public static class MyLibrary
     {
         public static void DoSomething()
         {
             // do some work
         }
         public static async Task DoSomethingAsync()
         {
             // do similar work but use async API,
             // can also simply call DoSomething().
         }
     }
     // In another part of code would be called like this:
     public static async Task BiggerMethod()
     {
         MyLibrary.DoSomething();
         await MyLibrary.DoSomethingAsync();
     }
