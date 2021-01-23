    [Flags]
    enum MyFlags
    {
        Foo = 0x0001,
        Bar = 0x0002, 
        Baz = 0x0004, 
        All = Foo | Bar | Baz
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyFlags flags = MyFlags.Foo | MyFlags.Baz;
            MyFlags isBar = MyFlags.Bar & flags;
            Console.WriteLine(isBar);
        }
    }
