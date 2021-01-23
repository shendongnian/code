    using System;
    public class Main
    {
      static void Main(string[] args)
      {
         Action<string> c = (x) => Console.WriteLine(x.ToLower());
         c.Invoke("Java2s.com"); // or simply c("Java2s.com");
      }
    }
