    [DllImport("msvcr120.dll")]
    public static extern int printf(string format, __arglist);
    public static void Main()
    {
        printf("Hello %s!\n", __arglist("World"));
        Console.ReadKey();
    }
