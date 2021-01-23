    static void Main()
    {
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = { 3, 2, 1 };
        var obj = CompareLists(arr1, arr2, EqualityComparer<int>.Default);
        Console.ReadLine();
    }
