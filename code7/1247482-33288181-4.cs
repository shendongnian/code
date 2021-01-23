    static void Main()
    {
        Console.Clear();
        // Call intDisplayArray1() to output on screen
        int[] array1 = intDisplayArray1();
        Console.Write("Array 1: " + string.Join(",", array1));
        Console.Read();
    }
    
    public static int[] intDisplayArray1()
    {
       // first array declaration
       int[] Array1 = { 5, 10, 15, 20 };
       return Array1;
    }
