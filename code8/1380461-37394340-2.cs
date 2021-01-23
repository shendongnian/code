    public static String ToString(double d)
    {
        return (d * 1000.0).ToString("0000");
    }
    Console.WriteLine(ToString(24.1));
    Console.WriteLine(ToString(0.5));
    Console.WriteLine(ToString(9.0));
