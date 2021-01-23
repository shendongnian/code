    static void ChangeFirstItemToTen(int[] arr)
    {
        arr[0] = 10;
    }
    
    static void ChangeFirstItemToTen(Array arr)
    {
        arr.SetValue(10, 0);
    }
    
    static void Main(string[] args)
    {
        int[] values = new int[] { 5, 6, 7, 8 };
        ChangeFirstItemToTen(values);
        Console.WriteLine(values[0]); // prints 10;
    }
