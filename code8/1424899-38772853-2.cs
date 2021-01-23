    static int[] array = new int[] { 5 };
    
    static void Main(string[] args)
    {
        var array2 = array;
        ModifyRef(ref array2);
    
        foreach (var item in array)
            Console.WriteLine(item);
        foreach (var item in array2)
            Console.WriteLine(item);
    }
    
    private static void ModifyRef(ref int[] array)
    {
        array = new int[1];
        array[0] = 10;
    }
