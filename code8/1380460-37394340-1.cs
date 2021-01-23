    public static String ToString(double d)
    {
        return string.Format("{0}{1:000}", (int)d, (d - (int)d) * 1000);
    }
    Console.WriteLine(ToString(24.1));
    Console.WriteLine(ToString(0.5));
    Console.WriteLine(ToString(9.0));
