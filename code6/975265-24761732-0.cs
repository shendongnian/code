    public static void Main()
    {
        int i = 2147483647;
        int j = checked((int)(i + 1)); // <==== note "checked"
        Console.WriteLine(j);
        Console.ReadKey();
    }
