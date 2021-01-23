    public static void Main()
    {
        File.WriteAllText("line.txt", Console.ReadLine());
        if (GetValue() < -2.0)
            Console.Write(2.0);
        if (GetValue() < -1.0 && GetValue() >= -2.0)
            Console.Write(1.0);
        if (GetValue() < 0.0 && GetValue() >= -1)
            Console.Write(0.0);
        if (GetValue() >= 0.0 && GetValue() < 1.0)
            Console.Write(GetValue());
        if (GetValue() >= 1.0)
            Console.Write(1.0);
        File.Delete("line.txt");
    }
    public static double GetValue()
    {
        return double.Parse(File.ReadAllText("line.txt"));
    }
