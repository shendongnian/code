    private static void Main(string[] args)
    {
        var sw1 = new Stopwatch();
        bool b1 = true;
        sw1.Start();
        for (int i = 0; i < 10 * 1000 * 1000; i++)
        {
            b1 = b1 ^ AreEqual(i, i + 1);
        }
        sw1.Stop();
        Console.WriteLine(b1);
        Console.WriteLine(sw1.ElapsedTicks);
        var sw2 = new Stopwatch();
        bool b2 = true;
        sw2.Start();
        for (int i = 0; i < 10 * 1000 * 1000; i++)
        {
            b2 = b2 ^ AreEqualEx(i, i + 1);
        }
        sw2.Stop();
        Console.WriteLine(b2);
        Console.WriteLine(sw2.ElapsedTicks);
    }
    public static bool AreEqual<T>(T a, T b)
    {
        return a.Equals(b);
    }
    public static bool AreEqualEx<T>(T a, T b) where T:IEquatable<T>
    {
        return a.Equals(b);
    }
