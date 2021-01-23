    static void Main(string[] args)
    {
        var a = new DerivedGetter<Bb, Aa>();
        Console.WriteLine(a.Get() is Bb);
    }
