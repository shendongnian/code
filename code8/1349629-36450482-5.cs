    using System;
    public class Main
    {
      static void Main()
      {
         Action<string> c = (x) => Console.WriteLine(x.ToLower());
         c.Invoke("Java2s.com");
      }
    }
