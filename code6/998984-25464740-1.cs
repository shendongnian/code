    static void foo()
    {
    }
    static void Main(string[] args)
    {
        Delegate fooDelegate = new Action(foo);
        IntPtr p = Marshal.GetFunctionPointerForDelegate(fooDelegate);
        Console.WriteLine(p);
    }
