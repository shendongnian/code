    unsafe static void Main(string[] args)
    {
        MyClass mc = new myClass();
        Console.WriteLine(mc.ToString()); // prints 1, 2, 3, 4, 5, 6, 7, 8, 9
        mc.B[2] = 42; // now parameter[5] set to 42
        Console.WriteLine(mc.ToString()); // prints 1, 2, 3, 4, 5, 42, 7, 8, 9
    }
