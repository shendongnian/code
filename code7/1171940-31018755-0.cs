    using System;
    
    class Test
    {
      static void Main()
      {            
        var xyz = Log(1, true) ? Log(2, true) : Log(3, true) ? Log(4, false) : Log(5, true);
      }
        
      static bool Log(int x, bool result)
      {
        Console.WriteLine(x);
        return result;
      }
    }
