      using System;
      class Test
      {
        static void receive(int x, double y)
        {
          Console.WriteLine("receive(int x, double y)");
        }
        static void receive(double x, int y)
        {
          Console.WriteLine("receive(double x, int y)");
        }
    
        static void Main()
        {
          receive(5, 10.2);
        }
     }
