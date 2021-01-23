    using System;
    using System.Threading.Tasks;
    using System.Timers;
    
    class Example
    {
       public int ElapsedIntervals { get; set; }
       public int RequiredIntervals { get; set; }
       public Timer timer { get; set; }
       static void Main()
       {
          waitTimer(1000000); //mwahahahaha
          Console.Write("Press any key to exit... ");
          Console.ReadKey();
       }
       // waitTimer and OnTimedEvent code...
    }
