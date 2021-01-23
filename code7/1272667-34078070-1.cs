    using System;
    class Program {
        static void Main()
        {
            Console.Title = Console.ReadLine();
            if (double.Parse(Console.Title) < -2.0) { Console.Write(2.0); }
            if ((double.Parse(Console.Title) < -1.0) && (double.Parse(Console.Title) >= -2.0)) { Console.Write(1.0); }
            if ((double.Parse(Console.Title) < 0.0) && (double.Parse(Console.Title) >= -1)) { Console.Write(0.0); }
            if ((double.Parse(Console.Title) >= 0.0) && (double.Parse(Console.Title) < 1.0)) { Console.Write(double.Parse(Console.Title)); }
            if (double.Parse(Console.Title) >= 1.0) { Console.Write(1.0); }
        }
    }
