    using System;
    public class Program
    {
    const string STAR = "*";
    const string SPACE = " ";
    const int COUNTER = 10;
    public static void Main(string[] args)
    {
      firsthalf();
      sechalf();
      Console.ReadLine();
     }
     static public void firsthalf()
     {
      for (int r = 0; r < COUNTER; r++)
      {
         for (int c = 0; c <= r; c++)
            Console.Write(STAR);
         Console.WriteLine("{0}", (r + 1) * 2);
      }
      Console.WriteLine();
    }
    static public void sechalf()
    {
      for (int r = COUNTER; r > 0; r--)
      {
         for (int c = 0; c < r; c++)
            Console.Write(STAR);
         Console.WriteLine("{0}", (r + 0) * 2);
         //Console.WriteLine();
      }
      Console.WriteLine();
    }
    }
