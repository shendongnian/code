    [DllImport( "Native.dll", CallingConvention = CallingConvention.Cdecl )]
    private static extern int foo( ref double var1, ref double var2 );
    public static void Main( string[] args )
    {
        FooTest();
    }
    private static void FooTest()
    {
        double var1 = 0;
        double var2 = 0;
        foo( ref var1, ref var2 );
        Console.Out.WriteLine( "Var1: {0:0.0}; Var2: {1:0.0}", var1, var2 );
        // Prints "Var1: 5.0; Var2: 7.0"
    }
