    static void Main(string[] args)
    {
        int? x = 1;
        Foo(ref x);
        Console.WriteLine(x);//Writes 2
    }
    private static void Foo(ref int? y)
    {
        y += 1;
        var l = new List<int?>();
        l.Add(y);
        l[0] += 1;//This does not affect the value of x devlared in Main
        Console.WriteLine(l[0]);//Writes 3
        Console.WriteLine(y);//writes 2
        Foo2(l);
    }
    private static void Foo2(List<int?> l)
    {
        l[0] += 1;
        Console.WriteLine(l[0]);//writes 4
    }
