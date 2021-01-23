    using System;
    public class Main
    {
      static void Main()
      {
         Action<string> c = (s) => Console.WriteLine(s.ToLower());
         c.Invoke("Java2s.com");
      }
    }
