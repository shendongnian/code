    class Program
    {
      static Timer timer = new Timer(TimeSpan.FromMinutes(5).Milliseconds);
      static void Main(string[] args)
      {
        Console.WriteLine("----Calling my method----");
        timer.AutoReset = true;
        timer.Elapsed += timer_Elapsed;
        timer.Start();
        Console.ReadLine();
      }
      static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
        MyMethod();
      }
      private static void MyMethod()
      {
        Console.WriteLine("*** Method is executed at {0} ***", DateTime.Now);
        Console.ReadLine();
      }
    }
