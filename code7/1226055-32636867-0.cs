    public static void Main()
    {
         for (var i = 0; i < 2; i++)
         {
             var t = new Thread(() => Console.WriteLine(DateTime.Now));
             t.Start();
             Thread.Sleep(2000);
         }
         Console.ReadKey();
     }
