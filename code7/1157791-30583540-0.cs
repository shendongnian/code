    public class MyParams
    {
        public int X { get; set; }
    }
    public static void bob(MyParams p)
    {
        p.X += 2;
    }
    static void Main()
    {
        MyParams p = new MyParams { X = 0 };
        bob(p);
        p.X += 1;
        bob(p);
        Console.WriteLine(p.X);
    }
