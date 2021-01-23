    using System;
    using System.Linq;
						
    public class Program
    {
      public static void Main()
      {
        var a = "10.001000";
        var b = a.Reverse().SkipWhile(i => i == '0').Reverse();
        var c = new String(b.ToArray());
			
        Console.WriteLine(a);
        Console.WriteLine(c);
      }
    }
