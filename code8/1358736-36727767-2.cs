    private static void Main()
    {
        int[] array = {3, 6, 4, 1, 3, 4, 2, 5, 3, 0};
        Console.WriteLine(IsSolvable(array));
        Console.ReadKey();
    }
    private static bool IsSolvable(int[] array)
    {
        if (array.Length <= 1)
            return false;
        int index = array[0];
        if (index < array.Length && array[index] == 0)
            return true;
        // this is where the recursion magic happens
        return IsSolvable(array.Skip(1).ToArray());
    }
