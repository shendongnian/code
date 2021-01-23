    static void Main()
    {
        (new Action<double>(x =>
        {
            if (x < -2.0) { Console.Write(2.0); }
            if ((x < -1.0) && (x >= -2.0)) { Console.Write(1.0); }
            if ((x < 0.0) && (x >= -1)) { Console.Write(0.0); }
            if ((x >= 0.0) && (x < 1.0)) { Console.Write(x); }
            if (x >= 1.0) { Console.Write(1.0); }
        }))(double.Parse(Console.ReadLine()));
        Console.ReadKey();
    }
