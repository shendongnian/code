    public class Test
    {
      private bool loop = true;
 
      public static void Main()
      {
        Test test = new Test();
        Thread thread = new Thread(DoStuff);
        thread.Start(test);
 
        Thread.Sleep(1000);
 
        test.loop = false;
        Console.WriteLine("loop is now false");
      }
 
      private static void DoStuff(object o) {
        Test test = (Test)o;
        Console.WriteLine("Entering loop");
        while (test.loop) {
 
        }
        Console.WriteLine("Exited loop");
      }
 
  }
