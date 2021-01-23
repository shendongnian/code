    using System;
    using System.Threading.Tasks;
    using System.Timers;
    
    class Example
    {
       static void Main()
       {
          Timer timer = new Timer(1000);
          timer.Elapsed += async ( sender, e ) => await HandleTimer();
          timer.Start();
          Console.Write("Press any key to exit... ");
          Console.ReadKey();
       }
    
       private static Task HandleTimer()
       {
         Console.WriteLine("\nHandler not implemented..." );
         throw new NotImplementedException();
       }
    }
