    using System;
    using System.Globalization;
    using System.Threading;
    public class TestClass
    {
       public static void Main()
       {
          Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    
          DateTime dt = DateTime.Now;
          Console.WriteLine("Today is {0}", DateTime.Now.ToString("d"));
    
          // Increments dt by one day.
          dt = dt.AddDays(1);
          Console.WriteLine("Tomorrow is {0}", dt.ToString("d"));
    
       }
    }
