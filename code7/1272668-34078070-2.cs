    using System;
    class Program {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Main(new string[] { Console.ReadLine() });
            }
            else
            {
                if (double.Parse(args[0]) < -2.0) { Console.Write(2.0); }
                if ((double.Parse(args[0]) < -1.0) && (double.Parse(args[0]) >= -2.0)) { Console.Write(1.0); }
                if ((double.Parse(args[0]) < 0.0) && (double.Parse(args[0]) >= -1)) { Console.Write(0.0); }
                if ((double.Parse(args[0]) >= 0.0) && (double.Parse(args[0]) < 1.0)) { Console.Write(double.Parse(args[0])); }
                if (double.Parse(args[0]) >= 1.0) { Console.Write(1.0); }
            }
        }
    }
